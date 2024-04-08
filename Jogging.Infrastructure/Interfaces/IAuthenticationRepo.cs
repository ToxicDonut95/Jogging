using Jogging.Infrastructure.Models;

namespace Jogging.Infrastructure.Interfaces
{
    public interface IAuthenticationRepo
    {
        Task<Person?> AuthenticateAsync(string email, string password);
        Task<Person?> SignUpAsync(string email, string password);
    }
}
