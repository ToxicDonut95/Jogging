namespace Jogging.Rest.DTOs;

public class PersonResultDTO
{
    public int PersonId { get; set; }
    public PersonDTO Person { get; set; }
    public int ResultId { get; set; }
    public RegistrationDTO Registration { get; set; }
}