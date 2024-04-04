using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Infrastructure.Models;
using Supabase;
namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    internal class PersonRepo : IGenericRepo<Person>
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

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
            //use pagedList helper klasse in domein
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
