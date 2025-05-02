using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using HMSAPI.Model.GenericModel;

public class EncryptDataMiddleware
{
    private readonly RequestDelegate _next;

    public EncryptDataMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Temporarily hold the original response body
        var originalBody = context.Response.Body;

        using var newBody = new MemoryStream();
        context.Response.Body = newBody;

        await _next(context); // Wait for rest of the pipeline

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var bodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        if (!string.IsNullOrWhiteSpace(bodyText) &&
            context.Response.ContentType != null &&
            context.Response.ContentType.Contains("application/json"))
        {
            try
            {
                var responseObj = JsonSerializer.Deserialize<APIResponseModel>(bodyText, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (responseObj?.Data != null)
                {
                    string rawDataJson = JsonSerializer.Serialize(responseObj.Data);
                    string encryptedData = AESHelper.Encrypt(rawDataJson);
                    responseObj.Data = encryptedData;

                   // var modifiedJson = JsonSerializer.Serialize(responseObj);

                    var modifiedJson = JsonSerializer.Serialize(responseObj, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
                    });
                    var modifiedBytes = Encoding.UTF8.GetBytes(modifiedJson);

                    context.Response.ContentLength = modifiedBytes.Length;
                    context.Response.Body = originalBody;
                    await context.Response.Body.WriteAsync(modifiedBytes);
                    return;
                }
            }
            catch { /* Just fallback to original response */ }
        }

        // If not processed above, copy original back
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        await newBody.CopyToAsync(originalBody);
        context.Response.Body = originalBody;
    }
}
