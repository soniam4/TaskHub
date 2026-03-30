namespace Api.Controllers.Tasks.Response
{
    // Ответ сервера с информацией о задаче
    public class TaskResponse
    {
        // уникальный идентификатор задачи
        public Guid Id { get; set; }

        // заголовок задачи
        public string? Title { get; set; }

        // id создателя задачи
        public Guid CreatedByUserId { get; set; }

        // время создания задачи (UTC)
        public DateTimeOffset CreatedUtc { get; set; }
    }
}