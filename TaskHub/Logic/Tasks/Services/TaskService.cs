using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dal.Entities;
using Logic.Tasks.UseCases;

namespace Logic.Tasks.Services
{
    public class TaskService : ITaskService
    {
        // поля для юзкейсов
        private readonly ICreateTaskUseCase _createTaskUseCase;
        private readonly IGetTasksUseCase _getTasksUseCase;
        private readonly IGetTaskUseCase _getTaskUseCase;
        private readonly ISetTaskTitleUseCase _setTaskTitleUseCase;
        private readonly IDeleteTaskUseCase _deleteTaskUseCase;
        private readonly IDeleteTasksUseCase _deleteTasksUseCase;

        public TaskService(
            ICreateTaskUseCase createTaskUseCase,
            IGetTasksUseCase getTasksUseCase,
            IGetTaskUseCase getTaskUseCase,
            ISetTaskTitleUseCase setTaskTitleUseCase,
            IDeleteTaskUseCase deleteTaskUseCase,
            IDeleteTasksUseCase deleteTasksUseCase)
        {
            // инициализация зависимостей
            _createTaskUseCase = createTaskUseCase;
            _getTasksUseCase = getTasksUseCase;
            _getTaskUseCase = getTaskUseCase;
            _setTaskTitleUseCase = setTaskTitleUseCase;
            _deleteTaskUseCase = deleteTaskUseCase;
            _deleteTasksUseCase = deleteTasksUseCase;
        }

        public async Task<TaskEntity> CreateTaskAsync(string? title, Guid userId, CancellationToken cancellationToken)
        {
            // создаём задачу через юзкейс
            return await _createTaskUseCase.ExecuteAsync(title, userId, cancellationToken);
        }

        public async Task<List<TaskEntity>> GetAllTasksAsync(CancellationToken cancellationToken)
        {
            return await _getTasksUseCase.ExecuteAsync(cancellationToken);
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            // поиск задачи по id
            return await _getTaskUseCase.ExecuteAsync(id, cancellationToken);
        }

        public async Task<bool> SetTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken)
        {
            return await _setTaskTitleUseCase.ExecuteAsync(id, title, cancellationToken);
        }

        public async Task<bool> DeleteTaskAsync(Guid id, CancellationToken cancellationToken)
        {
            // удаляем одну задачу
            return await _deleteTaskUseCase.ExecuteAsync(id, cancellationToken);
        }

        public async Task DeleteAllTasksAsync(CancellationToken cancellationToken)
        {
            await _deleteTasksUseCase.ExecuteAsync(cancellationToken);
        }
    }
}