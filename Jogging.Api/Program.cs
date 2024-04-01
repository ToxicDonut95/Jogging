﻿using Jogging.Infrastructure.Repositories;
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
        
        // default connection url => http://localhost:8000
        // docker exec supabase-kong env => get connection key
        /*var supabaseConfiguration = builder.Configuration
            .GetSection("Supabase")
            .Get<SupabaseConfiguration>(); // A class used to hold the configuration

        // Attempt to create Supabase client
        Supabase.Client supabaseClient = null;
        try
        {
            supabaseClient = new Supabase.Client(supabaseConfiguration.SupabaseUrl, supabaseConfiguration.SupabaseKey);
        }
        catch (Exception ex)
        {
            // Log connection error
            var logger = builder.Services.BuildServiceProvider().GetService<ILogger<Program>>();
            logger.LogError(ex, "Failed to establish connection to Supabase.");
        }

        // Add supabase to depedency injector
        if (supabaseClient != null)
        {
            builder.Services.AddScoped(_ => supabaseClient);
        }*/
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}