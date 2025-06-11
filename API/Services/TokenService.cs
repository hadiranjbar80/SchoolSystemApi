using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(School school)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, school.SchoolCode)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_config.GetValue<int>("Jwt:ExpDate")),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}