namespace Jogging.Domain.Models;

public class PersonResultRequestDOM
{
    public int PersonId { get; set; }
    public PersonResponseDOM PersonResponse { get; set; }
    public int ResultId { get; set; }
    public RegistrationResponseDOM RegistrationResponse { get; set; }
}