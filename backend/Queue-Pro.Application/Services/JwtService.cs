using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Queue_Pro.Application.Settings;
using Queue_Pro.Domain.Models;

namespace Queue_Pro.Application.Services;

public class JwtService(IOptions<AuthSettings> authSettings)
{
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim("id", user.Id.ToString()),
            new Claim("username", user.Username),
            new Claim("firstName", user.FirstName),
            new Claim("lastName", user.LastName),
        };

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow + authSettings.Value.Expires,
            claims: claims,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}