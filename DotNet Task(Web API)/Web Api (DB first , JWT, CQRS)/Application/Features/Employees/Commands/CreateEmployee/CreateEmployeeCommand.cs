using Application.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponseDto>
    {
        public string Name { get; set; } = null!;

        public string Department { get; set; } = null!;

        public string Role { get; set; } = null!;

        [Range(typeof(decimal), "50000", "10000000", ErrorMessage = "Salary must be between 50000 to 10000000.")]
        public decimal Salary { get; set; }
    }
}