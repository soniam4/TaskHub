namespace Api.Controllers.Tasks.Request
{
    // Запрос на создание новой задачи
    public class CreateTaskRequest
    {
        // заголовок задачи 
        public string? Title { get; set; }

        // id пользователя, который создаёт задачу
        public Guid CreatedByUserId { get; set; }
    }
}