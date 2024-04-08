﻿using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Infrastructure.Models;
using Supabase;
namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    public class PersonRepo : IGenericRepo<Person>
    {
        Client _client;

        public PersonRepo(Client client)
        {
            _client = client;
        }

        public void Add(Person item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person item)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var result = await _client.From<Person>().Get();
            return result.Models;
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
