using System;
using System.Threading;
using System.Threading.Tasks;
using Logic.Tasks.Repositories;

namespace Logic.Tasks.UseCases
{
    // Интерфейс для удаления всех задач
    public interface IDeleteTasksUseCase
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }

    // Юзкейс удаления всех задач
    public class DeleteTasksUseCase : IDeleteTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTasksUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            // вызываем репозиторий для удаления всех записей
            await _taskRepository.DeleteAllAsync(cancellationToken);
        }
    }
}