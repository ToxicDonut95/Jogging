﻿using AutoMapper;
using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.DomeinControllers
{
    public class PersonsManager
    {
        private IAuthenticationRepo _authRepo;
        private IGenericRepo<Person> _personRepo;
        private IMapper _mapper;
        public PersonDOM LoggedInPerson { get; private set; }

        public PersonsManager(IAuthenticationRepo authRepo, IGenericRepo<Person> personRepo, IMapper mapper)
        {
            _authRepo = authRepo;
            _personRepo = personRepo;
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

        public async Task<bool> SignUpAsync(string email, string password)
        {
            var loggedInPerson = _mapper.Map<PersonDOM>(await _authRepo.SignUpAsync(email, password));
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

        public async Task<IEnumerable<PersonDOM>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PersonDOM>>(await _personRepo.GetAllAsync());
        }

        public async Task CreatePerson(PersonDOM person)
        {
            _personRepo.AddAsync(_mapper.Map<Person>(person));
        }
    }
}