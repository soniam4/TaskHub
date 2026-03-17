using System;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    // Контекст базы данных для работы с задачами
    public class TaskDbContext : DbContext
    {
        // Таблица задач
        public DbSet<TaskEntity> Tasks { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // настройка сущности Task
            modelBuilder.Entity<TaskEntity>(entity =>
            {
                // первичный ключ
                entity.HasKey(t => t.Id);

                // ограничение на длину заголовка
                entity.Property(t => t.Title).HasMaxLength(500);

                // значение по умолчанию для даты создания
                entity.Property(t => t.CreatedUtc).HasDefaultValueSql("now()");

                // связь с таблицей пользователей 
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(t => t.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // игнорируем User
            modelBuilder.Ignore<User>();

            base.OnModelCreating(modelBuilder);
        }
    }
}