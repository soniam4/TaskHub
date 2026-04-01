using Dal;
using Logic.Tasks.Repositories;
using Logic.Tasks.Services;
using Logic.Tasks.UseCases;
using Logic.Users.Services;
using Logic.Users.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Logic;

/// <summary>
/// Регистрация зависимостей слоя логики
/// </summary>
public static class LogicStartUp
{
    /// <summary>
    /// Добавить зависимости логики: сервисы
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public static void AddLogic(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        // Task repository
        services.AddScoped<ITaskRepository, TaskRepository>();

        // Task use cases
        services.AddScoped<ICreateTaskUseCase, CreateTaskUseCase>();
        services.AddScoped<IGetTasksUseCase, GetTasksUseCase>();
        services.AddScoped<IGetTaskUseCase, GetTaskUseCase>();
        services.AddScoped<ISetTaskTitleUseCase, SetTaskTitleUseCase>();
        services.AddScoped<IDeleteTaskUseCase, DeleteTaskUseCase>();
        services.AddScoped<IDeleteTasksUseCase, DeleteTasksUseCase>();

        // Task service
        services.AddScoped<ITaskService, TaskService>();
       
    }
}