using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
public class DecryptQueryFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (HttpMethods.IsGet(context.HttpContext.Request.Method) || HttpMethods.IsDelete(context.HttpContext.Request.Method))
        {
            foreach (var arg in context.ActionArguments)
            {
                var value = arg.Value;
                if (value == null) continue;

                var type = value.GetType();

                if (type == typeof(string))
                {
                    try
                    {
                        var decrypted = AESHelper.Decrypt(value as string);
                        if (int.TryParse(decrypted, out int intResult))
                        {
                            context.ActionArguments[arg.Key] = intResult;
                        }
                        else
                        {
                            context.ActionArguments[arg.Key] = decrypted;
                        }
                    }
                    catch
                    {
                        // Handle/log decryption error if needed
                    }
                }

                else
                {
                    // It's a complex object (like a query model)
                    var properties = type.GetProperties();
                    foreach (var prop in properties)
                    {
                        if (prop.PropertyType == typeof(string) && prop.CanRead && prop.CanWrite)
                        {
                            var encryptedValue = prop.GetValue(value) as string;
                            if (!string.IsNullOrEmpty(encryptedValue))
                            {
                                try
                                {
                                    var decrypted = AESHelper.Decrypt(encryptedValue);
                                    prop.SetValue(value, decrypted);
                                }
                                catch
                                {
                                    // Handle/log decryption error if needed
                                }
                            }
                        }
                    }
                }
            }
        }

        await next();
    }
}



















//public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//{
//    var req = context.ActionArguments//HttpContext.Request;

//    if (req.QueryString.HasValue)
//    {
//        var sb = new StringBuilder();

//        // Decrypt each incoming query value
//        foreach (var kv in req.Query)
//        {
//            var name = kv.Key;
//            var encrypted = HttpUtility.UrlDecode(kv.Value);



//            // Or for simple string values:
//            var plainText = AESHelper.Decrypt(encrypted);

//            sb.AppendFormat("{0}{1}={2}",
//                sb.Length == 0 ? "?" : "&",
//                HttpUtility.UrlEncode(name),
//                HttpUtility.UrlEncode(plainText));
//        }
//        context.HttpContext.Request.QueryString = new QueryString(sb.ToString());

//        await next();


// Swap in the decrypted query string for model binding





