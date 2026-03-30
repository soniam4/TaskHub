using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

// Фильтр для валидации запроса на создание задачи
public class ValidateCreateTaskRequestFilter : ActionFilterAttribute
{
    // Вызывается ПЕРЕД выполнением действия контроллера
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // 1. Проверяем, что в запросе вообще есть тело (параметр request)
        if (!context.ActionArguments.TryGetValue("request", out var requestObj) || requestObj == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        // 2. Приводим к нужному типу
        var request = requestObj as CreateTaskRequest;

        // Если не удалось привести — тоже ошибка
        if (request == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        // 3. Проверяем, что указан создатель задачи (UserId не пустой)
        if (request.CreatedByUserId == Guid.Empty)
        {
            context.Result = new BadRequestObjectResult("Идентификатор пользователя не задан");
            return;
        }

        // 4. Проверяем, что название задачи не пустое и не только пробелы
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            context.Result = new BadRequestObjectResult("Название задачи не задано");
            return;
        }

        // Если все проверки прошли — фильтр завершается, выполняется контроллер
    }

    // После выполнения действия ничего делать не нужно
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // пусто, потому что валидация уже выполнена
    }
}