using Api.Attributes;
using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Logic.Tasks.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks
{
    // Контроллер для управления задачами
    [ApiController]
    [Route("tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // создание новой задачи
        [HttpPost]
        public async Task<ActionResult<TaskResponse>> CreateTaskAsync(
            [FromBody] CreateTaskRequest request,
            CancellationToken cancellationToken)
        {
            var task = await _taskService.CreateTaskAsync(request.Title, request.CreatedByUserId, cancellationToken);

            var response = new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                CreatedByUserId = task.CreatedByUserId,
                CreatedUtc = task.CreatedUtc
            };
            return CreatedAtAction(nameof(GetTaskByIdAsync), new { id = task.Id }, response);
        }

        // получение всех задач
        [HttpGet]
        public async Task<ActionResult<List<TaskResponse>>> GetAllTasksAsync(CancellationToken cancellationToken)
        {
            var tasks = await _taskService.GetAllTasksAsync(cancellationToken);

            // преобразуем список задач в ответ
            var response = tasks.Select(t => new TaskResponse
            {
                Id = t.Id,
                Title = t.Title,
                CreatedByUserId = t.CreatedByUserId,
                CreatedUtc = t.CreatedUtc
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<TaskResponse>> GetTaskByIdAsync(
            [FromRouteTaskId] Guid id,
            CancellationToken cancellationToken)
        {
            var task = await _taskService.GetTaskByIdAsync(id, cancellationToken);
            if (task == null) return NotFound();
            var response = new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                CreatedByUserId = task.CreatedByUserId,
                CreatedUtc = task.CreatedUtc
            };

            return Ok(response);
        }

        [HttpPut("{id}/title")]
        public async Task<IActionResult> SetTaskTitleAsync(
            [FromRouteTaskId] Guid id,
            [FromBody] SetTaskTitleRequest request,
            CancellationToken cancellationToken)
        {
            var updated = await _taskService.SetTaskTitleAsync(id, request.Title!, cancellationToken);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskByIdAsync(
            [FromRouteTaskId] Guid id,
            CancellationToken cancellationToken)
        {
            var deleted = await _taskService.DeleteTaskAsync(id, cancellationToken);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // удаление всех задач
        [HttpDelete]
        public async Task<IActionResult> DeleteAllTasksAsync(CancellationToken cancellationToken)
        {
            await _taskService.DeleteAllTasksAsync(cancellationToken);
            return NoContent();
        }
    }
}