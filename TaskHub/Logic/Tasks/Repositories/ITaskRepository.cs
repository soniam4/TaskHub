using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dal.Entities;

namespace Logic.Tasks.Repositories
{
    // Интерфейс репозитория для работы с задачами
    public interface ITaskRepository
    {
        // создание новой задачи в БД
        Task<TaskEntity> CreateAsync(TaskEntity task, CancellationToken cancellationToken);

        // получение всех задач
        Task<List<TaskEntity>> GetAllAsync(CancellationToken cancellationToken);

        // поиск задачи по идентификатору
        Task<TaskEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        // обновление заголовка задачи (возвращает true если успешно)
        Task<bool> UpdateTitleAsync(Guid id, string title, CancellationToken cancellationToken);

        // удаление задачи по id
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);

        // удаление всех задач
        Task DeleteAllAsync(CancellationToken cancellationToken);
    }
}