namespace CQRS.Application.Commands;

    using MediatR;
public class CreateTaskCommand : IRequest<int> // The command to create a new task, returning the ID of the created task
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

