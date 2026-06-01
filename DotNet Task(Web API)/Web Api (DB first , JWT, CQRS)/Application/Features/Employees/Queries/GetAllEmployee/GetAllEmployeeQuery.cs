using Application.DTOs;
using MediatR;

namespace Application.Features.Employees.Queries.GetAllEmployee
{
    public class GetAllEmployeeQuery : IRequest<List<EmployeeResponseDto>>
    {
    }
}
