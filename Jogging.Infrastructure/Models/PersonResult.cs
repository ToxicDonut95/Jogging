using Postgrest.Attributes;

namespace Jogging.Infrastructure.Models;

[Table("PersonResult")]
public class PersonResult
{
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int ResultId { get; set; }
    public Registration Registration { get; set; }
}