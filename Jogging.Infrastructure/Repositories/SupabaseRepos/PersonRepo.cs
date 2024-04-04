using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Infrastructure.Models;

namespace Jogging.Infrastructure.Repositories.SupabaseRepos
{
    internal class PersonRepo : IGenericRepo<Person>
    {
        //SupabaseClient _client;
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
