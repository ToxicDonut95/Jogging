using Jogging.Api.Configuration;
using Jogging.Infrastructure.Repositories;
using Jogging.Rest.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Supabase;

namespace Jogging.Api;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(MappingConfig));
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSupabase(builder.Configuration);
        builder.Services.AddRateLimiter(RateLimiterConfigurator.ConfigureRateLimiter);
        builder.Services.AddCors();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRateLimiter();

        app.UseCors(CorsConfigurator.ConfigureCors); // AllowCredentials() niet samen met AllowAnyOrigin()
        
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}