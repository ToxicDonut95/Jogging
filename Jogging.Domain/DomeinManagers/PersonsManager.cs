using AutoMapper;
using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.DomeinControllers
{
    public class PersonsManager
    {
        IAuthenticationRepo _authRepo;
        IGenericRepo<Person> _personRepo;
        IMapper _mapper;
        public PersonDOM LoggedInPerson { get; private set; }

        public PersonsManager(IAuthenticationRepo authRepo, IGenericRepo<Person> personRepo, IMapper mapper)
        {
            _authRepo = authRepo;
            _personRepo = personRepo;
            _mapper = mapper;
        }

        public bool LogIn(string email, string password)
        {
            LoggedInPerson = _mapper.Map<PersonDOM>(_authRepo.Authenticate(email, password));
            if (LoggedInPerson == null)
            {
                return false;
            }
            else return true;
        }
        public IEnumerable<PersonDOM> GetAll()
        {
            return _personRepo.GetAll().Select(person => _mapper.Map<PersonDOM>(person));
        }
    }
}
