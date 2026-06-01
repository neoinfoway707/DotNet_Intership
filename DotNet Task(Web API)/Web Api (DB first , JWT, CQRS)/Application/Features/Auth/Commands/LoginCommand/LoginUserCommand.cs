using MediatR;

namespace Application.Features.Auth.Commands.LoginCommand
{
    public class LoginUserCommand:IRequest<String>
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
