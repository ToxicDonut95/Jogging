using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Infrastructure.Models;
using Supabase;

namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    public class PersonRepo : IGenericRepo<Person>
    {
        private Client _client;

        public PersonRepo(Client client)
        {
            _client = client;
        }

        public void Add(Person item)
        {
            _client.From<Person>().Insert(item);
        }

        public async Task<int> AddAsync(Person item)
        {
            var addedPerson = await _client.From<Person>().Insert(item);

            return addedPerson.Model;
        }

        public void Delete(Person item)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Person>> GetAllAsync()
        {
            var result = await _client
                .From<Person>()
                .Get();
            return result.Models.AsQueryable();
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}