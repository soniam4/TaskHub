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

            return CreatedAtAction("GetTaskById", new { id = task.Id }, response);
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

        // получение задачи по id
        [HttpGet("{id:guid}", Name = "GetTaskById")]
        public async Task<ActionResult<TaskResponse>> GetTaskByIdAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var task = await _taskService.GetTaskByIdAsync(id, cancellationToken);
            if (task == null)
            {
                return NotFound(); // задача не найдена
            }

            var response = new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                CreatedByUserId = task.CreatedByUserId,
                CreatedUtc = task.CreatedUtc
            };

            return Ok(response);
        }

        // обновление заголовка задачи
        [HttpPut("{id:guid}/title")]
        public async Task<IActionResult> SetTaskTitleAsync(
            [FromRoute] Guid id,
            [FromBody] SetTaskTitleRequest request,
            CancellationToken cancellationToken)
        {
            var updated = await _taskService.SetTaskTitleAsync(id, request.Title!, cancellationToken);
            if (!updated)
            {
                return NotFound(); // не удалось обновить
            }

            return NoContent();
        }

        // удаление задачи по id
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTaskByIdAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var deleted = await _taskService.DeleteTaskAsync(id, cancellationToken);
            if (!deleted)
            {
                return NotFound(); // задача не найдена
            }

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