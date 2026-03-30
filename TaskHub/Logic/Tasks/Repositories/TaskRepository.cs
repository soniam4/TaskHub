using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dal;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logic.Tasks.Repositories
{
    // Репозиторий для работы с задачами в БД
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskEntity> CreateAsync(TaskEntity task, CancellationToken cancellationToken)
        {
            // добавляем задачу в контекст
            await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return task;
        }

        public async Task<List<TaskEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            // получаем все задачи из БД
            return await _dbContext.Tasks.ToListAsync(cancellationToken);
        }

        public async Task<TaskEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            // поиск по id
            return await _dbContext.Tasks.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<bool> UpdateTitleAsync(Guid id, string title, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(new object[] { id }, cancellationToken);
            if (task == null)
            {
                return false; // задача не найдена
            }

            task.Title = title;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(new object[] { id }, cancellationToken);
            if (task == null)
            {
                return false; // ничего не удалили
            }

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task DeleteAllAsync(CancellationToken cancellationToken)
        {
            // удаляем все задачи сразу
            await _dbContext.Tasks.ExecuteDeleteAsync(cancellationToken);
        }
    }
}