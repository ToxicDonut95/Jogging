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

    public async Task<Competition> AddAsync(Competition competition)
    {
        var existingCompetition = await GetByIdAsync(competition.Id);

        if (existingCompetition != null)
        {
            return existingCompetition;
        }
        
        var response = await _client
            .From<Competition>()
            .Insert(competition);

        return response.Model;
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

    public void Update(Competition item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Competition item)
    {
        throw new NotImplementedException();
    }
}