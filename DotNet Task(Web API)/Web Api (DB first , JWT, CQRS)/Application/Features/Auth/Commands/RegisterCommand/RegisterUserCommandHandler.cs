using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterUserCommandHandler(IUserRepository repository) : IRequestHandler<RegisterUserCommand, UserResponseDto?>
    {
        public async Task<UserResponseDto?> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            var hash = new PasswordHasher<User>().HashPassword(user,request.Password);
            
            user.Username = request.Username;
            user.Password = hash;
            
            var check = await repository.GetUserByCredentials(user);
            if (check != null)
                return null;
            
            bool add = await repository.AddUser(user);
            if (!add)
                return null;
            
            return new UserResponseDto
            {
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
