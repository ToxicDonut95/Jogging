using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Infrastructure.Models;

namespace Jogging.Infrastructure.Repositories.SupabaseRepos;

public class CompetitionRepo : IGenericRepo<Competition>
{
    private readonly Supabase.Client _client;

    public CompetitionRepo(Supabase.Client client)
    {
        _client = client;
    }

    public void Add(Competition competition)
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<Competition>> GetAllAsync()
    {
        var result = await _client.From<Competition>().Get();
        return result.Models.AsQueryable();
    }

    public async Task<Competition> GetByIdAsync(int id)
    {
        var existingCompetition = await _client
            .From<Competition>()
            .Where(c => c.Id == id)
            .Get();

        return existingCompetition.Model;
    }

    public async Task<Competition> AddAsync(Competition competition)
    {
        var response = await _client
            .From<Competition>()
            .Insert(competition);

        return response.Model;
    }
    public async Task<Competition> UpdateAsync(int id, Competition updatedCompetition)
    {
        var response = await _client
            .From<Competition>()
            .Where(c => c.Id ==  id)
            .Get();
        var competition = response.Model;

        if (competition != null)
        {
            competition.Name = updatedCompetition.Name;
            competition.Date = updatedCompetition.Date;
            competition.AddressId = updatedCompetition.AddressId;

            await _client
                .From<Competition>()
                .Upsert(competition);

            return competition;
        }

        return null;
    }

    public async Task DeleteAsync(int competitionId)
    {
        await _client
            .From<Competition>()
            .Where(c => c.Id ==competitionId)
            .Delete();
    }

    public void Update(Competition item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Competition item)
    {
        throw new NotImplementedException();
    }
}