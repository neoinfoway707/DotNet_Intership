using Application.DTOs;
using Application.Interfaces;
using DB_Approach_CRUD.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler(IEmployeeRepository _repo)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponseDto>
    {
        public async Task<EmployeeResponseDto> Handle(
            GetEmployeeByIdQuery request,
            CancellationToken cancellationToken)
        {
            var employee = await _repo.GetEmployeeById(request.Id);
            if (employee == null)
                return null;

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
    }
}
