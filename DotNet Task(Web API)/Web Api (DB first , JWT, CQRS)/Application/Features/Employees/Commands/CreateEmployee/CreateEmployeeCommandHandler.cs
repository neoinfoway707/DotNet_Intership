using Application.DTOs;
using Application.Interfaces;
using DB_Approach_CRUD.Domain.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler(IEmployeeRepository _repo) : IRequestHandler<CreateEmployeeCommand, EmployeeResponseDto>
    {
        public async Task<EmployeeResponseDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = new EmployeeCrud
            {
                Name = request.Name,
                Department = request.Department,
                Role = request.Role,
                Salary = request.Salary
            };

            var addEmp = await _repo.AddAsync(emp);

            if (!addEmp)
                return null;

            return new EmployeeResponseDto
            {
                Id = emp.Id,
                Name = emp.Name,
                Department = emp.Department,
                Role = emp.Role,
                Salary = emp.Salary
            };
        }
    }
}
