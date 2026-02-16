using CQRS.Application.Commands;
using CQRS.Models;
using MediatR;


namespace TaskManagerCQRS.Application.Handlers;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly AppDbContext _context;

    public CreateTaskCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            Status = "Pending"
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return task.Id; // return dynamically generated Id
    }
}
