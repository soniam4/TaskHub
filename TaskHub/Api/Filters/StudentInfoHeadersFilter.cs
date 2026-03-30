using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

// Фильтр добавляет заголовки с информацией о студенте в каждый ответ
public class StudentInfoHeadersFilter : ActionFilterAttribute
{
    // Вызывается ПЕРЕД выполнением действия контроллера
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Добавляем кастомные заголовки с ФИО и группой
        context.HttpContext.Response.Headers.TryAdd("X-Student-Name", "Matveeva Sonia Vadimovna");
        context.HttpContext.Response.Headers.TryAdd("X-Student-Group", "RI-240912");
    }

    // После выполнения действия ничего делать не нужно
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // пусто, потому что заголовки уже добавлены
    }
}