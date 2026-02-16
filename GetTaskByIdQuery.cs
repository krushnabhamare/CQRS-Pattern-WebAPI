using CQRS.Models;
using MediatR;

namespace CQRS.Application.Queries;

public class GetTaskByIdQuery : IRequest<TaskItem?>
{
    public int Id { get; set; }
}