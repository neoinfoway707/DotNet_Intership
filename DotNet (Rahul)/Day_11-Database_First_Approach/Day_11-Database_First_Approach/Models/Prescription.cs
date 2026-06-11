using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day_11_Database_First_Approach.Models;

public partial class Prescription
{
    [Key] // Marks this as the Primary Key
    public int Id { get; set; }

    [Required(ErrorMessage = "Patient name is required.")]
    [StringLength(100, ErrorMessage = "Patient name cannot exceed 100 characters.")]
    [Display(Name = "Patient Name")]
    public string PatientName { get; set; } = null!;

    [Required(ErrorMessage = "Doctor name is required.")]
    [StringLength(100, ErrorMessage = "Doctor name cannot exceed 100 characters.")]
    [Display(Name = "Doctor Name")]
    public string DoctorName { get; set; } = null!;

    [Required(ErrorMessage = "Prescription date is required.")]
    [DataType(DataType.Date)] 
    [Display(Name = "Prescription Date")]
    public DateTime PrescriptionDate { get; set; }

    [Required]
    [Display(Name = "Medicine")]
    public int MedicineId { get; set; }

    public bool IsDeleted { get; set; }

    public Medicine? Medicine { get; set; } = null!;
}
