using CQRS.Application.Commands;
using CQRS.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
    {
        var taskId = await _mediator.Send(command);
        return Ok(new { TaskId = taskId });
    }

    // GET: api/tasks
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _mediator.Send(new GetAllTasksQuery());
        return Ok(tasks);
    }

    // GET: api/tasks/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _mediator.Send(new GetTaskByIdQuery { Id = id });
        if (task == null) return NotFound();
        return Ok(task);
    }

    // PUT: api/tasks/{id}/status
// PUT: api/tasks/{id}
[HttpPut("{id}")]
public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskCommand command)
{
    // Ensure the command has the correct Id
    command.Id = id;

    var updated = await _mediator.Send(command);

    if (!updated)
        return NotFound();

    return Ok(new { Message = "Task updated successfully" });
}


}