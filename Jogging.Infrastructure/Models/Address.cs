using Postgrest.Models;
using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Infrastructure.Models;
[Table("Address")]
public class Address : BaseModel
{
    [PrimaryKey]
    public int Id { get; set; }
    [Column("Street")]
    public string Street { get; set; }
    [Column("City")]
    public string City { get; set; }

    [Reference(typeof(Person), ReferenceAttribute.JoinType.Left)]
    public List<Person> People { get; set; }
    [Reference(typeof(Competition), ReferenceAttribute.JoinType.Left)]
    public List<Competition> Competitions { get; set; }
}