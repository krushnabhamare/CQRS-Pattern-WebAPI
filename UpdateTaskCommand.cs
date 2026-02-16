using MediatR;

namespace CQRS.Application.Commands;

public class UpdateTaskCommand : IRequest<bool>  // returns true if updated successfully
{
    public int Id { get; set; }  // Task Id to update
    public string? Status { get; set; }  // You can add more fields as needed, like DueDate, etc.
}
