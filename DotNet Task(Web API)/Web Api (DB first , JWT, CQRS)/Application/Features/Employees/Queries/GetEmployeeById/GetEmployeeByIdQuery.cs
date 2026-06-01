using Application.DTOs;
using DB_Approach_CRUD.Persistance.Repositories;
using MediatR;

namespace Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponseDto>
    {
        public int Id { get; set; }
    }
}
