using System;
using Jogging.Domain.Exceptions;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.Validators
{
    public static class PersonValidator
    {
        public static void ValidatePersonRequest(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || 
                string.IsNullOrWhiteSpace(person.LastName) || 
                person.BirthDate == null)
            {
                throw new InvalidRequestException("Firstname, lastname, and birthdate are required.");
            }
            
            if (person.BirthDate > DateTime.Now)
            {
                throw new InvalidRequestException("Birthdate cannot be in the future.");
            }
            
            int maxAllowedAge = 150;
            if (DateTime.Now.Year - person.BirthDate.Year > maxAllowedAge)
            {
                throw new InvalidRequestException($"Birthdate cannot be more than {maxAllowedAge} years ago.");
            }
        }
    }
}