using Application.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand: IRequest<EmployeeResponseDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Department { get; set; } = null!;

        public string Role { get; set; } = null!;

        [Range(typeof(decimal), "50000", "10000000", ErrorMessage = "Salary must be between 50000 to 10000000.")]
        public decimal Salary { get; set; }
    }
}
