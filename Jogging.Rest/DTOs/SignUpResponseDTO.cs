namespace Jogging.Rest.DTOs;

public class SignUpResponseDTO
{
    public Guid userId { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    public PersonResponseDTO PersonResponse { get; set; }
}