using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;
using Client = Supabase.Client;

namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly Client _client;
        private readonly IGenericRepo<Person> _personRepo;


        public AuthenticationRepo(Client client, IGenericRepo<Person> personRepo)
        {
            _client = client;
            _personRepo = personRepo;
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

        public async Task<Person?> SignUpAsync(string email, string password, Person signedUpPerson)
        {
            var session = await _client.Auth.SignUp(email, password);
            if (session?.User?.Id == null)
            {
                return null;
            }
            
            var userid = session.User.Id;
            var person = await _client.From<Person>()
                .Where(x => x.UserId == userid)
                .Single();
            if (person != null)
            {
                return person;
            }
            
            signedUpPerson.UserId = userid;
            var response = await _client.From<Person>()
                .Insert(signedUpPerson);
            return response.Model;
        }

        public async Task<bool> RequestPasswordAsync(string personEmail)
        {
            return await _client.Auth.ResetPasswordForEmail(personEmail);
        }
    }
}