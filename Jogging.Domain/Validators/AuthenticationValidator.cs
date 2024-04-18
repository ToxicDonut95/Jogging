using System.Text.RegularExpressions;
using Jogging.Domain.Exceptions;

namespace Jogging.Domain.Validators;

public class AuthenticationValidator
{
    public static void ValidateEmailInput(string email)
    {
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        
        if (!Regex.IsMatch(email, pattern))
        {
            throw new InvalidEmailException("Invalid email address format.");
        }
    }
}