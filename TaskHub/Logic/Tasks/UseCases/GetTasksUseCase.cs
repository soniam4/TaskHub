using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dal.Entities;
using Logic.Tasks.Repositories;

namespace Logic.Tasks.UseCases
{
    // Интерфейс для получения всех задач
    public interface IGetTasksUseCase
    {
        Task<List<TaskEntity>> ExecuteAsync(CancellationToken cancellationToken);
    }

    // Юзкейс получения списка задач
    public class GetTasksUseCase : IGetTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskEntity>> ExecuteAsync(CancellationToken cancellationToken)
        {
            // получаем все задачи из репозитория
            return await _taskRepository.GetAllAsync(cancellationToken);
        }
    }
}