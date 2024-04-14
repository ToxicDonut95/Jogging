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

        public async Task<IEnumerable<CompetitionPerCategory>> GetRegisteredCompetionsOfPerson(int personId)
        {
            var personRegistrationresult = await _client.From<PersonRegistration>().Where(pR => pR.PersonId == personId).Get();
            IEnumerable<int> registrationIds = personRegistrationresult.Models.Select(pR => pR.RegistrationId);
            var registrationsResult = await _client.From<Registration>().Where(r => registrationIds.Contains(r.Id)).Get();
            IEnumerable<int> competitionPerCatIds = registrationsResult.Models.Select(r => r.CompetitionPerCategoryId);
            var competitionPerCategoryResult = await _client.From<CompetitionPerCategory>().Where(cPC => competitionPerCatIds.Contains(cPC.Id)).Get();
            return competitionPerCategoryResult.Models;
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