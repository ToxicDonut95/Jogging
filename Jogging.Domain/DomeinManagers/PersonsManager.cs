using AutoMapper;
using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.DomeinControllers
{
    public class PersonsManager
    {
        private IGenericRepo<Person> _personRepo;
        private IMapper _mapper;

        public PersonsManager(IGenericRepo<Person> personRepo, IMapper mapper)
        {
            _personRepo = personRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponseDOM>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PersonResponseDOM>>(await _personRepo.GetAllAsync());
        }

        public async Task<int> CreatePerson(PersonResponseDOM personResponse)
        {
            var result = _personRepo.AddAsync(_mapper.Map<Person>(personResponse)).Result;
            return result.Id;
        }
    }
}