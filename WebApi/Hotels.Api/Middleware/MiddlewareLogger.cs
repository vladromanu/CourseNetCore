using System.Threading.Tasks;
using Hotels.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Hotels.Api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareLogger
    {
        private readonly RequestDelegate _next;

        public MiddlewareLogger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, INotificationService notificationService)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
           
            notificationService.Notify($"Handling request: {httpContext.Request.Path} {httpContext.Request.Method}");

            await _next.Invoke(httpContext);

            watch.Stop();
            notificationService.Notify($"Request handled finished ! Time: {watch.ElapsedMilliseconds} ms");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareLoggerExtensions
    {
        public static IApplicationBuilder UseMiddlewareLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareLogger>();
        }
    }
}