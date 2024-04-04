using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;
using Supabase;

namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    internal class AuthenticationRepo : IAuthenticationRepo
    {
        Client _client;


        public AuthenticationRepo(Client client)
        {
            _client = client;
        }
        public Person Authenticate(string email, string psswd)
        {
            var session = _client.Auth.SignIn(email, psswd);
            var userid = session.Result.User.Id;
            var person = _client.From<Person>().Where(x => x.UserId == userid).Single().Result;
            return person;
        }
    }
}
