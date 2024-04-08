using System.Text;
using Jogging.Api.Configuration;
using Jogging.Api.Middlewares;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Services;
using Jogging.Rest.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Jogging.Api;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(MappingConfig));
        
        var configuration = builder.Configuration.GetSection("Jwt").Get<JwtConfiguration>();
        builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("Jwt"));
        builder.Services.AddSingleton<ITokenBlacklistService, TokenBlacklistService>();
        builder.Services.AddCustomAuthentication(configuration);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddSupabase(builder.Configuration);
        builder.Services.AddRepoServices();
        builder.Services.AddDomeinManagerServices();

        builder.Services.AddRateLimiter(RateLimiterConfigurator.ConfigureRateLimiter);
        builder.Services.AddCors();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "JWTToken_Auth_API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "joggingapi v1"); });
        }

        app.UseRateLimiter();

        app.UseCors(CorsConfigurator.ConfigureCors); // AllowCredentials() niet samen met AllowAnyOrigin()

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<JwtTokenValidationMiddleware>();

        app.MapControllers();

        app.Run();
    }
}