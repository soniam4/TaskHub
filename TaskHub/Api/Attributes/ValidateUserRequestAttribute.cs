using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class ValidateUserRequestAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Проверяем, есть ли параметр request
        var request = context.ActionArguments.FirstOrDefault(x => x.Key.ToLower().Contains("request")).Value;

        if (request == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        // Пытаемся найти свойство Name через рефлексию
        var nameProperty = request.GetType().GetProperty("Name");
        if (nameProperty != null)
        {
            var nameValue = nameProperty.GetValue(request) as string;
            if (string.IsNullOrWhiteSpace(nameValue))
            {
                context.Result = new BadRequestObjectResult("Имя пользователя не задано");
                return;
            }
        }

        base.OnActionExecuting(context);
    }
}