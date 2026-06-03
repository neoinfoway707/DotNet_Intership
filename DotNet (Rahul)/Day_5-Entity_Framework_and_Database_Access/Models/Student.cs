using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_5_Entity_Framework_Database_Access.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Name required.")]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Address required.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid email address.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Course Name required.")]
        public string Course { get; set; }
        
        [Required(ErrorMessage = "Class Name required.")]
        public string Class { get; set; }
        
        [Required(ErrorMessage = "Tuation Fee required.")]
        [Range(100000,500000,ErrorMessage ="Tuation Fee must between 100000 to 500000 range.")]
        [Column(TypeName ="decimal(8,2)")]
        public decimal TuationFee { get; set; }
    }
}
