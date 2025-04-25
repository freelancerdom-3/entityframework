using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DecryptQueryMiddleware
{
    private readonly RequestDelegate _next;

    public DecryptQueryMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;

        if (HttpMethods.IsGet(request.Method) || HttpMethods.IsDelete(request.Method))
        {
            var originalQuery = QueryHelpers.ParseQuery(request.QueryString.Value ?? string.Empty);
            var newQuery = new Dictionary<string, string>();
            bool isModified = false;

            foreach (var kvp in originalQuery)
            {
                string key = kvp.Key;
                string value = kvp.Value;

                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        // Only decrypt if the original type is string (like id passed as encrypted string)
                        string decryptedValue = AESHelper.Decrypt(value);
                        newQuery[key] = decryptedValue;
                        isModified = true;
                    }
                    catch
                    {
                        // If decryption fails, fallback to original
                        newQuery[key] = value;
                    }
                }
            }

            if (isModified)
            {
                var updatedQueryString = QueryString.Create(newQuery);
                context.Request.QueryString = updatedQueryString;
            }
        }

        await _next(context);
    }
}
