using VivaAerobus.API.Utils;
using System.Net;
using System.Net.Mime;

namespace VivaAerobus.API.Middlewares
{
    public class ApiKeyMiddleware
    {
        private const string API_KEY = "ApiKey";

        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var appSettings = httpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKeyConfig = appSettings.GetValue<string>(API_KEY);

            if (!httpContext.Request.Headers.TryGetValue(API_KEY, out var apiKeyValue) || !apiKeyValue.Equals(apiKeyConfig))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                await httpContext.Response.WriteAsync(ResponseProvider.GetUnauthorizedMessage());
                return;
            }

            await _next(httpContext);
        }
    }
}
