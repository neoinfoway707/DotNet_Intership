using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day_15_Validation_and_Routing_with_WebAPI.Dtos
{
    public class JobsDto
    {
        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(50, ErrorMessage = "Job title cannot exceed 50 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(50, ErrorMessage = "Company name cannot exceed 50 characters.")]
        public string Company { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
        public string Location { get; set; } = null!;

        [Required(ErrorMessage = "Job type is required.")]
        [StringLength(50, ErrorMessage = "Job type cannot exceed 50 characters.")]
        public string JobType { get; set; } = null!; // e.g., "Full-time", "Remote"

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1000, 10000000, ErrorMessage = "Salary must be between 1,000 and 10,000,000.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Job status (IsActive) is required.")]
        public bool IsActive { get; set; }
    }
}
