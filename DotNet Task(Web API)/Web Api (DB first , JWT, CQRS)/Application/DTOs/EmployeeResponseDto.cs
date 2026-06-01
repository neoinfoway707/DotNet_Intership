using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Department { get; set; } = null!;

        public string Role { get; set; } = null!;

        public decimal Salary { get; set; } = 50000;

        public bool? IsDelete { get; set; } = false;
    }
}
