using System;
using System.Threading;
using System.Threading.Tasks;
using Dal.Entities;
using Logic.Tasks.Repositories;

namespace Logic.Tasks.UseCases
{
    // Интерфейс для создания задачи
    public interface ICreateTaskUseCase
    {
        Task<TaskEntity> ExecuteAsync(string? title, Guid userId, CancellationToken cancellationToken);
    }

    // Реализация юзкейса создания задачи
    public class CreateTaskUseCase : ICreateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskEntity> ExecuteAsync(string? title, Guid userId, CancellationToken cancellationToken)
        {
            // создаём новую сущность задачи
            var task = new TaskEntity
            {
                Id = Guid.NewGuid(),
                Title = title,
                CreatedByUserId = userId,
                CreatedUtc = DateTimeOffset.UtcNow
            };

            // сохраняем через репозиторий
            return await _taskRepository.CreateAsync(task, cancellationToken);
        }
    }
}