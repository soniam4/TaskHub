using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class ResponseTimeHeaderAttribute : ActionFilterAttribute
{
    private DateTime _startTime;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _startTime = DateTime.UtcNow;
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (!context.HttpContext.Response.HasStarted)
        {
            var elapsedMs = (DateTime.UtcNow - _startTime).TotalMilliseconds;
            context.HttpContext.Response.Headers.TryAdd("X-Response-Time-Ms", elapsedMs.ToString("F0"));
        }
        base.OnActionExecuted(context);
    }
}