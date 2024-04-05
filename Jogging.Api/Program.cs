using Jogging.Api.Configuration;
using Jogging.Rest.Mapping;

namespace Jogging.Api;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(MappingConfig));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddControllers();
        builder.Services.AddSupabase(builder.Configuration);
        builder.Services.AddRepoServices();
        builder.Services.AddDomeinManagerServices();

        builder.Services.AddRateLimiter(RateLimiterConfigurator.ConfigureRateLimiter);
        builder.Services.AddCors();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        app.UseCors(cors => cors
                //.SetIsOriginAllowed(origin => true)
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "joggingapi v1");
            });
        }
        app.UseRateLimiter();

        app.UseCors(CorsConfigurator.ConfigureCors); // AllowCredentials() niet samen met AllowAnyOrigin()

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}