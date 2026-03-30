using System;
using System.Threading;
using System.Threading.Tasks;
using Logic.Tasks.Repositories;

namespace Logic.Tasks.UseCases
{
    // Интерфейс для обновления заголовка задачи
    public interface ISetTaskTitleUseCase
    {
        Task<bool> ExecuteAsync(Guid id, string title, CancellationToken cancellationToken);
    }

    // Юзкейс изменения названия задачи
    public class SetTaskTitleUseCase : ISetTaskTitleUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public SetTaskTitleUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> ExecuteAsync(Guid id, string title, CancellationToken cancellationToken)
        {
            // передаём вызов в репозиторий для обновления
            return await _taskRepository.UpdateTitleAsync(id, title, cancellationToken);
        }
    }
}