using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;
using Supabase;

namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        Client _client;


        public AuthenticationRepo(Client client)
        {
            _client = client;
        }

        public async Task<Person?> AuthenticateAsync(string email, string password)
        {
            var session = await _client.Auth.SignIn(email, password);
            if (session == null || session.User == null)
            {
                return null;
            }

            var userId = session.User.Id;
            var person = await _client.From<Person>()
                .Where(x => x.UserId == userId)
                .Single();
            return person;
        }

        public async Task<Person?> SignUpAsync(string email, string password)
        {
            var session = await _client.Auth.SignUp(email, password);
            if (session == null || session.User == null)
            {
                return null;
            }

            var userid = session.User.Id;
            var person = await _client.From<Person>()
                .Where(x => x.UserId == userid)
                .Single();
            return person;
        }
    }
}