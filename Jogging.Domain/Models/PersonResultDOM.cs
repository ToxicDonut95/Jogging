namespace Jogging.Domain.Models;

public class PersonResultDOM
{
    public int PersonId { get; set; }
    public PersonDOM Person { get; set; }
    public int ResultId { get; set; }
    public RegistrationDOM Registration { get; set; }
}