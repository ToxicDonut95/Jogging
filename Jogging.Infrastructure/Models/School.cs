using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;
using Postgrest.Models;

namespace Jogging.Infrastructure.Models;

[Table("School")]
public class School: BaseModel
{
    [PrimaryKey]
    public int Id { get; set; }

    [Required]
    [Column("Name")]
    public string Name { get; set; }

    [Reference(typeof(Person), ReferenceAttribute.JoinType.Left)]
    public List<Person> People { get; set; }
}