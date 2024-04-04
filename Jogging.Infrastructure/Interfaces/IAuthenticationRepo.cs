using Jogging.Infrastructure.Models;

namespace Jogging.Infrastructure.Interfaces
{
    public interface IAuthenticationRepo
    {
        Person Authenticate(string email, string psswd);
    }
}
