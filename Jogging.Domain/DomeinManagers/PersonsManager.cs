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

        public async Task<IEnumerable<PersonDOM>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PersonDOM>>(await _personRepo.GetAllAsync());
        }

        public async Task<int> CreatePerson(PersonDOM person)
        {
            var result = _personRepo.AddAsync(_mapper.Map<Person>(person)).Result;
            return result.Id;
        }
    }
}