using Microsoft.AspNetCore.Mvc.Filters;
using VivaAerobus.API.Utils;
using System.Net.Mime;
using System.Net;

namespace VivaAerobus.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string API_KEY = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKeyConfig = appSettings.GetValue<string>(API_KEY);

            if (!context.HttpContext.Request.Headers.TryGetValue(API_KEY, out var apiKeyValue) || !apiKeyValue.Equals(apiKeyConfig))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
                await context.HttpContext.Response.WriteAsync(ResponseProvider.GetUnauthorizedMessage());
                return;
            }

            await next();
        }
    }
}
