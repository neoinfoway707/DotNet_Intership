using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Employee_CRUD.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Role { get; set; }
        public double? Salary { get; set; }
    }
}
