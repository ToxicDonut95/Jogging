using AutoMapper;
using Jogging.Domain.Models;
using Jogging.Domain.Validators;
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

    public async Task<PersonResponseDOM> SignUpAsync(string email, string password, PersonRequestDOM singedUpPersonDom)
    {
        Person signedUpPerson = _mapper.Map<Person>(singedUpPersonDom);
        PersonValidator.ValidatePersonRequest(signedUpPerson);
        var loggedInPerson = _mapper.Map<PersonResponseDOM>(await _authRepo.SignUpAsync(email, password, signedUpPerson));
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

    public async Task<bool> RequestPasswordAsync(string personEmail)
    {
        return await _authRepo.RequestPasswordAsync(personEmail);
    }
}