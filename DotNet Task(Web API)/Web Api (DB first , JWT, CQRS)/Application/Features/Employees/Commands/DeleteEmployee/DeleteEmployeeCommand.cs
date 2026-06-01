using MediatR;

namespace Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
