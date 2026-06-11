using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_11_Database_First_Approach.Models;

public partial class Medicine
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Medicine name is required.")]
    [StringLength(100, ErrorMessage = "Medicine name cannot exceed 100 characters.")]
    [Display(Name = "Medicine Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Category is required.")]
    [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, 1000000.00, ErrorMessage = "Price must be between 0.01 and 10,000.00")]
    [Column(TypeName = "decimal(10,2)")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock quantity is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
    public int Stock { get; set; }

    public bool IsDeleted { get; set; }
}
