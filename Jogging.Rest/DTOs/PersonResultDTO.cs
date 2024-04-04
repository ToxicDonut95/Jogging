namespace Jogging.Infrastructure.Models;

public class PersonResult
{
    public int PersonId { get; set; }
    public PersonDTO Person { get; set; }
    public int ResultId { get; set; }
    public Registration Registration { get; set; }
}