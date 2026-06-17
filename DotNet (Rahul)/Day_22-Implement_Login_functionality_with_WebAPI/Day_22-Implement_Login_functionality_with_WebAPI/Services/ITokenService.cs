namespace Day_22_Implement_Login_functionality_with_WebAPI.Services
{
    public interface ITokenService
    {
        string GenerateToken(string Username, string role);
    }
}
