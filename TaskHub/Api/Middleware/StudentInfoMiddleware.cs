using Microsoft.AspNetCore.Http;
namespace Api.Middleware
{
    public class StudentInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public StudentInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.TryAdd("X-Student-Name", "Matveeva Sonia Vadimovna");
            context.Response.Headers.TryAdd("X-Student-Group", "RI-240912");

            await _next(context);
        }
    }
}
