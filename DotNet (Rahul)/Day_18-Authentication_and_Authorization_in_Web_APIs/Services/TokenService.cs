using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Services
{
    public class TokenService(IConfiguration _configuration) : ITokenService
    {
        public string GenerateToken(string Username, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,Username),
                new Claim(ClaimTypes.Role,role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWT:ExpiryMinutes"])),
                signingCredentials: creds
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
