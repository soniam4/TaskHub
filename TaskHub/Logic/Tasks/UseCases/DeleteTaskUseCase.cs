using System;
using System.Threading;
using System.Threading.Tasks;
using Logic.Tasks.Repositories;

namespace Logic.Tasks.UseCases
{
    // Интерфейс для удаления одной задачи по id
    public interface IDeleteTaskUseCase
    {
        Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }

    // Реализация юзкейса удаления задачи
    public class DeleteTaskUseCase : IDeleteTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            // делегируем удаление в репозиторий
            return await _taskRepository.DeleteAsync(id, cancellationToken);
        }
    }
}