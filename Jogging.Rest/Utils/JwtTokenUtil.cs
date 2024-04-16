using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Jogging.Api.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Jogging.Rest.Utils;

public static class JwtTokenUtil
{
    public static string Generate(JwtConfiguration configuration, string userId)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Key));
        var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        var claims = new[]
        {
            new Claim("UserId", userId)
        };
        var securityToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddDays(30),
            issuer: configuration.Issuer,
            audience: configuration.Audience,
            signingCredentials: signInCredentials,
            claims: claims
        );
        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(securityToken);
        
        return tokenString;
    }
    
    public static string GetUserIdFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

        if (jwtToken == null)
        {
            return null;
        }

        var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId");

        return userIdClaim?.Value;
    }

}