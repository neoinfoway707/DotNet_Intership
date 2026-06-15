namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Services
{
    public interface ITokenService
    {
        string GenerateToken(string Username, string role);
    }
}
