using CQRS.Application.Queries;
using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CQRS.Application.Handlers
{

    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskItem?>
    {
        private readonly AppDbContext _context;

        public GetTaskByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id);
        }
    }
}