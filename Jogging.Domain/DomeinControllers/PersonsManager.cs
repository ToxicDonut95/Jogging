using AutoMapper;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Interfaces;

namespace Jogging.Domain.DomeinControllers
{
    public class PersonsManager
    {
        IAuthenticationRepo _authRepo;
        IMapper _mapper;
        public PersonDOM LoggedInPerson { get; private set; }

        public PersonsManager(IAuthenticationRepo authrepo, IMapper mapper)
        {
            _authRepo = authrepo;
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
    }
}
