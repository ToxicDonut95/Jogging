using AutoMapper;
using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.DomeinControllers
{
    public class PersonsManager
    {
        private readonly IGenericRepo<Person> _personRepo;
        private readonly IMapper _mapper;

        public PersonsManager(IGenericRepo<Person> personRepo, IMapper mapper)
        {
            _personRepo = personRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDOM>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PersonDOM>>(await _personRepo.GetAllAsync());
        }

        public async Task CreatePerson(PersonDOM person)
        {
            _personRepo.Add(_mapper.Map<Person>(person));
        }
    }
}
