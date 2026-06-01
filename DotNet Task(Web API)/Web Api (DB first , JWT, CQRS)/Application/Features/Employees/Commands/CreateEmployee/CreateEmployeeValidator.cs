using FluentValidation;

namespace Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeValidator
        : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must under 50 characters.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name must contain only letters.");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Department is required.")
                .MaximumLength(50).WithMessage("Department must under 50 characters.")
                 .Matches(@"^[a-zA-Z\s]+$").WithMessage("Department must contain only letters.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .MaximumLength(50).WithMessage("Role must under 50 characters.")
                 .Matches(@"^[a-zA-Z\s]+$").WithMessage("Role must contain only letters.");

            RuleFor(x => x.Salary)
                .GreaterThan(49999).WithMessage("Salary must be more than 50000.");
        }
    }
}