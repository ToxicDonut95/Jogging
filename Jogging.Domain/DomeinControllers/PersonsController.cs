using AutoMapper;
using Jogging.Domain.Interfaces;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.DomeinControllers
{
    public class PersonsController
    {
        Irepo<Person> _personRepo;
        IMapper _mapper;
        public PersonDOM LoggedInPerson { get; private set; }

        public PersonsController(Irepo<Person> personRepo, IMapper mapper)
        {
            _personRepo = personRepo;
            _mapper = mapper;
        }

        public bool LogIn(PersonDOM person)
        {
            LoggedInPerson = _mapper.Map<PersonDOM>(_personRepo.FindOrDefault(_mapper.Map<Person>(person)));
            if (LoggedInPerson == null)
            {
                return false;
            }
            else return true;
        }
    }
}
