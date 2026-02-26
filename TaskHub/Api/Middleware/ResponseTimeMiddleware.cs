using Microsoft.AspNetCore.Http;
namespace Api.Middleware
{
    public class ResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var start = DateTime.UtcNow;

            var originalBody = context.Response.Body;
            using var memStream = new MemoryStream();
            context.Response.Body = memStream;

            try
            {
                await _next(context);

                var elapsedMs = (DateTime.UtcNow - start).TotalMilliseconds;

                context.Response.Headers.TryAdd("X-Response-Time-Ms", elapsedMs.ToString("F0"));

                memStream.Seek(0, SeekOrigin.Begin);
                await memStream.CopyToAsync(originalBody);
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
    }
}
