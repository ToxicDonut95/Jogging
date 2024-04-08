using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Jogging.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Jogging.Api.Configuration;

public static class AuthConfigurator
{
    public static void AddCustomAuthentication(this IServiceCollection services, JwtConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Key))
                };
            });

        // Method to check if a token is blacklisted
        static bool IsTokenBlacklisted(string token)
        {
            // Add your logic to check if the token is blacklisted
            // For demonstration purposes, we'll assume it's always blacklisted
            return true;
        }
    }
}