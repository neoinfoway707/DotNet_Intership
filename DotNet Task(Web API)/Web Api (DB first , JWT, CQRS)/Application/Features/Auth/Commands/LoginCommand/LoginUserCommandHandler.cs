using Application.Interfaces;
using DB_Approach_CRUD.Application.DTOs;
using DB_Approach_CRUD.Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.LoginCommand
{
    public class LoginUserCommandHandler(IUserRepository _repo,IJwtService service) : IRequestHandler<LoginUserCommand, String>
    {
        public async Task<String> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password
            };

            var check = await _repo.GetUserByCredentials(user);
            if(check == null)
                return null;

            var token = service.GenerateToken(user);
            return token;
        }
    }
}
