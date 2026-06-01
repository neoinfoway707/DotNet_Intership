using FluentValidation;

namespace Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithErrorCode("Usernmae is required.")
                .MaximumLength(50).WithMessage("Username must under 50 characters.")
                .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Username must contain only letters, numbers and spaces.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
