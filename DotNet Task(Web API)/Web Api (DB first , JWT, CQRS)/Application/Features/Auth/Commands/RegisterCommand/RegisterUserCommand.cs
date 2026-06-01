using Application.DTOs;
using MediatR;

namespace Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterUserCommand : IRequest<UserResponseDto?>
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
