using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Filters;

// Фильтр для логирования запросов — пишет в консоль начало и конец выполнения
public class RequestLoggingFilter : ActionFilterAttribute
{
    private Stopwatch _stopwatch;

    // Вызывается ПЕРЕД выполнением действия контроллера
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Получаем HTTP метод и путь запроса
        var httpMethod = context.HttpContext.Request.Method;
        var path = context.HttpContext.Request.Path;

        // Пишем в консоль начало выполнения
        Console.WriteLine($"[START] {httpMethod} {path}");

        // Запускаем таймер для замера времени выполнения
        _stopwatch = Stopwatch.StartNew();
    }

    // Вызывается ПОСЛЕ выполнения действия контроллера
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // Останавливаем таймер
        _stopwatch.Stop();

        // Получаем статус код ответа
        var statusCode = context.HttpContext.Response.StatusCode;

        // Пишем в консоль результат: статус и время выполнения в мс
        Console.WriteLine($"[END] {statusCode} - {_stopwatch.ElapsedMilliseconds}ms");
    }
}