using CQRS.Application.Queries;
using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerCQRS.Application.Handlers;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
{
    private readonly AppDbContext _context;

    public GetAllTasksQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tasks.ToListAsync();
    }
}
