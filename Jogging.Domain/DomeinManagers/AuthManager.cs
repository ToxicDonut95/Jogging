using AutoMapper;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.DomeinControllers;

public class AuthManager
{
    private readonly IAuthenticationRepo _authRepo;
    private readonly IMapper _mapper;
    public PersonResponseDOM LoggedInPersonResponse { get; private set; }

    public AuthManager(IAuthenticationRepo authRepo, IMapper mapper)
    {
        _authRepo = authRepo;
        _mapper = mapper;
    }

    public async Task<PersonResponseDOM?> LogInAsync(string email, string password)
    {
        var loggedInPerson = _mapper.Map<PersonResponseDOM>(await _authRepo.AuthenticateAsync(email, password));
        if (loggedInPerson == null)
        {
            return null;
        }
        else
        {
            LoggedInPersonResponse = loggedInPerson;
            return loggedInPerson;
        }
    }

    public async Task<bool> SignUpAsync(string email, string password, PersonResponseDOM signedUpPersonResponseDom)
    {
        var loggedInPerson = _mapper.Map<PersonResponseDOM>(await _authRepo.SignUpAsync(email, password, _mapper.Map<Person>(signedUpPersonResponseDom)));
        if (loggedInPerson == null)
        {
            return false;
        }
        else
        {
            LoggedInPersonResponse = loggedInPerson;
            return true;
        }
    }

    public async Task<bool> RequestPasswordAsync(string personEmail)
    {
        return await _authRepo.RequestPasswordAsync(personEmail);
    }
}