namespace Domain.Entities;

public partial class EmployeeCrud
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Role { get; set; } = null!;

    public decimal Salary { get; set; } = 50000;

    public bool? IsDelete { get; set; }
}
