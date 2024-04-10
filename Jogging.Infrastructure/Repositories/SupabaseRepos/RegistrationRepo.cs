using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;
using Supabase;
using static Postgrest.QueryOptions;

namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private Client _client;

        public RegistrationRepo(Client client)
        {
            _client = client;
        }

        public async Task<Registration> SigninToContestAsync(Registration registration, int personId)
        {
            var result = await _client.From<Registration>().Insert(registration, new Postgrest.QueryOptions { Returning = ReturnType.Representation });
            int registrationId = (int)result.Model.Id;
            await _client.From<PersonRegistration>().Insert(new PersonRegistration(personId, registrationId));
            return result.Model;
        }
    }
}