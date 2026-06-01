using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByCredentials(User user);

        Task<bool> AddUser(User user);
    }
}
