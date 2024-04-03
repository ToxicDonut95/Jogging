using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Jogging.Api.Configuration;

public class CorsConfigurator
{
    public static void ConfigureCors(CorsPolicyBuilder corsPolicyBuilder)
    {
        corsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    }
}