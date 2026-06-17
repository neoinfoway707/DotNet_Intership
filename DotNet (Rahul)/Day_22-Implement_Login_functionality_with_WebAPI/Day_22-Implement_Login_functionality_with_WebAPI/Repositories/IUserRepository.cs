using Day_22_Implement_Login_functionality_with_WebAPI.Dtos;
using Day_22_Implement_Login_functionality_with_WebAPI.Models;

namespace Day_22_Implement_Login_functionality_with_WebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterNewUser(UserRequestDto userDto);
        Task<User?> LoginUser(UserRequestDto userDto);
        Task<List<User>> GetAllUsers();
        Task<User?> UpdateUser(int id,UserRequestDto userDto);

    }
}
