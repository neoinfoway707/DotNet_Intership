using Application.DTOs;
using Application.Interfaces;
using DB_Approach_CRUD.Persistance.Repositories;
using MediatR;

namespace Application.Features.Employees.Queries.GetAllEmployee
{
    public class GetAllEmployeeQueryHandler(IEmployeeRepository _repo) : IRequestHandler<GetAllEmployeeQuery, List<EmployeeResponseDto>>
    {
        public async Task<List<EmployeeResponseDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repo.GetAllEmployee();
            if (employees == null)
                return null;
            return employees.Select(employee => new EmployeeResponseDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Role = employee.Role,
                Salary = employee.Salary,
                IsDelete = employee.IsDelete
            }).ToList();
        }
    }
}
