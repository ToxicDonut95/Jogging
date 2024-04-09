using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Domain.DomeinControllers;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;
using Jogging.Infrastructure.Repositories.SupabaseRepos;

namespace Jogging.Api.Configuration
{
    public static class GenericServiceExtension
    {
        public static void AddRepoServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationRepo, AuthenticationRepo>();
            services.AddScoped<IGenericRepo<Person>, PersonRepo>();
            services.AddScoped<IRegistrationRepo, RegistrationRepo>();
        }

        public static void AddDomeinManagerServices(this IServiceCollection services)
        {
            services.AddScoped<PersonsManager>();
        }
    }
}