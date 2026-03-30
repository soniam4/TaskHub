using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

// Фильтр для валидации запроса на обновление названия задачи
public class ValidateSetTaskTitleRequestFilter : ActionFilterAttribute
{
    // Вызывается ПЕРЕД выполнением действия контроллера
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // 1. Проверяем, что в запросе есть тело (параметр request)
        if (!context.ActionArguments.TryGetValue("request", out var requestObj) || requestObj == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        // 2. Приводим к нужному типу
        var request = requestObj as SetTaskTitleRequest;

        // Если не удалось привести — ошибка
        if (request == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        // Если все проверки прошли — фильтр завершается, выполняется контроллер
        // (дополнительных проверок для этого запроса не требуется)
    }

    // После выполнения действия ничего делать не нужно
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // пусто, потому что валидация уже выполнена
    }
}