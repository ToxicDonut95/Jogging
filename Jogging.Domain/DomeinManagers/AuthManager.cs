using AutoMapper;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.DomeinControllers;

public class AuthManager
{
    private readonly IAuthenticationRepo _authRepo;
    private readonly IMapper _mapper;
    public PersonDOM LoggedInPerson { get; private set; }

    public AuthManager(IAuthenticationRepo authRepo, IMapper mapper)
    {
        _authRepo = authRepo;
        _mapper = mapper;
    }

    public async Task<PersonDOM?> LogInAsync(string email, string password)
    {
        var loggedInPerson = _mapper.Map<PersonDOM>(await _authRepo.AuthenticateAsync(email, password));
        if (loggedInPerson == null)
        {
            return null;
        }
        else
        {
            LoggedInPerson = loggedInPerson;
            return loggedInPerson;
        }
    }

    public async Task<bool> SignUpAsync(string email, string password, PersonDOM signedUpPersonDOM)
    {
        var loggedInPerson = _mapper.Map<PersonDOM>(await _authRepo.SignUpAsync(email, password, _mapper.Map<Person>(signedUpPersonDOM)));
        if (loggedInPerson == null)
        {
            return false;
        }
        else
        {
            LoggedInPerson = loggedInPerson;
            return true;
        }
    }

    public async Task<bool> RequestPasswordAsync(string personEmail)
    {
        return await _authRepo.RequestPasswordAsync(personEmail);
    }
}