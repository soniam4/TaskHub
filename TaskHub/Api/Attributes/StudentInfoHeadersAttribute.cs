using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class StudentInfoHeadersAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (!context.HttpContext.Response.HasStarted)
        {
            context.HttpContext.Response.Headers.TryAdd("X-Student-Name", "Matveeva Sonia Vadimovna");
            context.HttpContext.Response.Headers.TryAdd("X-Student-Group", "RI-240912");
        }
        base.OnActionExecuted(context);
    }
}