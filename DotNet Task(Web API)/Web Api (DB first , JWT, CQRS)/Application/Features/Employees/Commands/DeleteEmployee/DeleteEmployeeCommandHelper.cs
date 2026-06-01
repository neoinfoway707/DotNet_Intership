using Application.Interfaces;
using MediatR;

namespace Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHelper(IEmployeeRepository _repo) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var check = await _repo.DeleteEmployee(request.Id);
            if (!check)
                return false;
            return true;
        }
    }
}
