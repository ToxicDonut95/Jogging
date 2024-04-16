using Postgrest.Attributes;
using Postgrest.Models;

namespace Jogging.Infrastructure.Models;

[Table("PersonResult")]
public class PersonRegistration : BaseModel
{
    [Column("PersonId")]
    public int PersonId { get; set; }

    //public Person Person { get; set; }
    [Column("ResultId")]
    public int RegistrationId { get; set; }

    //public Registration Registration { get; set; }
}