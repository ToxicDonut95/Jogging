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
        public Person? Authenticate(string email, string psswd)
        {
            var session = _client.Auth.SignIn(email, psswd);
            if (session.Result == null)
            {
                return null;
            }
            var userid = session.Result.User.Id;
            var person = _client.From<Person>().Where(x => x.UserId == userid).Single().Result;
            return person;
        }
        public Person? SignUp(string email, string psswd)
        {
            var session = _client.Auth.SignUp(email, psswd);
            if (!session.IsCompletedSuccessfully)
            {
                return null;
            }
            var userid = session.Result.User.Id;
            var person = _client.From<Person>().Where(x => x.UserId == userid).Single().Result;
            return person;
        }
    }
}
