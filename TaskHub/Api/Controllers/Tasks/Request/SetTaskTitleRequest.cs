namespace Api.Controllers.Tasks.Request
{
    // Запрос на обновление заголовка задачи
    public class SetTaskTitleRequest
    {
        // новый заголовок задачи (может быть пустым)
        public string? Title { get; set; }
    }
}