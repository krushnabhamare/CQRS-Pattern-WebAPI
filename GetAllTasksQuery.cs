using CQRS.Models;
using MediatR;
using System.Collections.Generic;

namespace CQRS.Application.Queries;

public class GetAllTasksQuery : IRequest<List<TaskItem>>
{
}