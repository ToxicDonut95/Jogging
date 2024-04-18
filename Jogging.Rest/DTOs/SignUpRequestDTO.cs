namespace Jogging.Rest.DTOs;

public class SignUpRequestDTO
{
    public string email { get; set; }
    public string password { get; set; }

    public PersonRequestDTO Person { get; set; }
}