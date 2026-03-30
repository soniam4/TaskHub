using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dal.Entities;

namespace Logic.Tasks.Services
{
    // Интерфейс сервиса для работы с задачами
    public interface ITaskService
    {
        // создание новой задачи
        Task<TaskEntity> CreateTaskAsync(string? title, Guid userId, CancellationToken cancellationToken);

        // получение всех задач
        Task<List<TaskEntity>> GetAllTasksAsync(CancellationToken cancellationToken);

        // поиск задачи по id
        Task<TaskEntity?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken);

        // обновление заголовка задачи
        Task<bool> SetTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken);

        // удаление одной задачи
        Task<bool> DeleteTaskAsync(Guid id, CancellationToken cancellationToken);

        // удаление всех задач
        Task DeleteAllTasksAsync(CancellationToken cancellationToken);
    }
}