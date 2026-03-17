using System;

namespace Dal.Entities
{
    // Сущность задачи в базе данных
    public class TaskEntity
    {
        // уникальный идентификатор задачи
        public Guid Id { get; set; }

        // заголовок задачи (может быть пустым)
        public string? Title { get; set; }

        // id пользователя, который создал задачу
        public Guid CreatedByUserId { get; set; }

        // дата и время создания в UTC
        public DateTimeOffset CreatedUtc { get; set; }
    }
}