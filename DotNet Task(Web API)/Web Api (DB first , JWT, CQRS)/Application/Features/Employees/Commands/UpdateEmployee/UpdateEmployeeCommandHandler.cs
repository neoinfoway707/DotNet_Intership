using Application.DTOs;
using Application.Interfaces;
using DB_Approach_CRUD.Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler(IEmployeeRepository _repo) : IRequestHandler<UpdateEmployeeCommand, EmployeeResponseDto>
    {
        public async Task<EmployeeResponseDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = new EmployeeCrud
            {
                Id = request.Id,
                Name = request.Name,
                Department = request.Department,
                Role = request.Role,
                Salary = request.Salary
            };

            var employee = await _repo.UpdateEmployee(emp);
            if (employee != null)
            {
                return new EmployeeResponseDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    Role = employee.Role,
                    Salary = employee.Salary,
                    IsDelete = employee.IsDelete
                };
            }
            return null;
        }
    }
}
