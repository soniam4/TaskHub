using System;
using System.Threading;
using System.Threading.Tasks;
using Dal.Entities;
using Logic.Tasks.Repositories;

namespace Logic.Tasks.UseCases
{
    // Интерфейс для получения одной задачи по id
    public interface IGetTaskUseCase
    {
        Task<TaskEntity?> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }

    // Реализация юзкейса получения задачи
    public class GetTaskUseCase : IGetTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskEntity?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            // ищем задачу по идентификатору в репозитории
            return await _taskRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}