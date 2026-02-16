using CQRS.Application.Commands;
using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerCQRS.Application.Handlers;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateTaskCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
            return false;

        // Only update if values are provided
    
        if (!string.IsNullOrWhiteSpace(request.Status))
            task.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
