using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Attributes;

// Кастомный атрибут для валидации id задачи из route
public class FromRouteTaskIdAttribute : ModelBinderAttribute
{
    public FromRouteTaskIdAttribute()
    {
        Name = "id";  // имя параметра в маршруте
        BinderType = typeof(TaskIdModelBinder);  // какой байндер использовать
    }
}

// Сам байндер — проверяет и парсит id
public class TaskIdModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        // получаем значение из route
        var value = bindingContext.ValueProvider.GetValue("id").FirstValue;

        // если id вообще не передали
        if (value == null)
        {
            bindingContext.ModelState.AddModelError("id", "Идентификатор задачи не задан");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        // если передали пустую строку или пробелы
        if (string.IsNullOrWhiteSpace(value))
        {
            bindingContext.ModelState.AddModelError("id", "Идентификатор задачи не задан");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        // пробуем распарсить как Guid
        if (!Guid.TryParse(value, out var guid))
        {
            bindingContext.ModelState.AddModelError("id", "Идентификатор задачи имеет некорректный формат");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        // всё ок — возвращаем распаршенный Guid
        bindingContext.Result = ModelBindingResult.Success(guid);
        return Task.CompletedTask;
    }
}