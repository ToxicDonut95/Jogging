namespace Jogging.Rest.DTOs;

public class SignUpDTO
{
    public string email { get; set; }
    public string password { get; set; }

    public PersonDTO person { get; set; }
}