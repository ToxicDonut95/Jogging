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

    public void Add(Competition item)
    {
        throw new NotImplementedException();
    }

    public void AddAsync(Competition item)
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<Competition>> GetAllAsync()
    {
        var result =  await _client.From<Competition>().Get();
        return result.Models.AsQueryable();
    }

    public Competition Get(int id)
    {
        throw new NotImplementedException();
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