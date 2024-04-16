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
            try
            {
                var personRegistrationresult = await _client.From<PersonRegistration>().Where(pR => pR.PersonId == personId).Get();
                IEnumerable<int> registrationIds = personRegistrationresult.Models.Select(pR => pR.RegistrationId);
                var registrationsResult = await _client.From<Registration>().Get();
                var personalRegistrations = registrationsResult.Models.Where(r => registrationIds.Contains(r.Id));
                IEnumerable<int> competitionPerCatIds = personalRegistrations.Select(r => r.CompetitionPerCategoryId);
                var competitionPerCategoryResult = await _client.From<CompetitionPerCategory>().Get();
                var personalCompetitionsPerCategories = competitionPerCategoryResult.Models.Where(cPC => competitionPerCatIds.Contains(cPC.Id));
                return personalCompetitionsPerCategories.AsEnumerable<CompetitionPerCategory>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Registration> SigninToContestAsync(Registration registration, int personId)
        {
            try
            {
                var result = await _client.From<Registration>().Insert(registration, new Postgrest.QueryOptions { Returning = ReturnType.Representation });
                int registrationId = (int)result.Model.Id;
                PersonRegistration personRegistration = new PersonRegistration() { PersonId = personId, RegistrationId = registrationId };
                await _client.From<PersonRegistration>().Insert(personRegistration);
                return result.Model;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}