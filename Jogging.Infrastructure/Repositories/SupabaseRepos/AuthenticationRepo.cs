using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;

namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    internal class AuthenticationRepo : IAuthenticationRepo
    {
        Supabase.Client _client;

        public PersonRepo(Client client)
        {
            _client = client;
        }
        public Person Authenticate(string email, string psswd)
        {
            throw new NotImplementedException();
        }
    }
}
