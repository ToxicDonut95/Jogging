using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Supabase;
using System;
using Jogging.Infrastructure.Repositories;

namespace Jogging.Api.ServiceExtensions
{
    public static class SupabaseServiceExtension
    {
        public static void AddSupabase(this IServiceCollection services, IConfiguration configuration)
        {
            var supabaseConfiguration = configuration.GetSection("Supabase").Get<SupabaseConfiguration>();
            if (supabaseConfiguration == null)
            {
                throw new InvalidOperationException("Supabase configuration is missing.");
            }

            Supabase.Client supabaseClient = null;
            try
            {
                supabaseClient = new Supabase.Client(supabaseConfiguration.SupabaseUrl, supabaseConfiguration.SupabaseKey);
            }
            catch (Exception ex)
            {
                var loggerFactory = services.BuildServiceProvider().GetService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Failed to establish connection to Supabase.");
            }

            if (supabaseClient != null)
            {
                services.AddScoped(_ => supabaseClient);
            }
        }
    }
}