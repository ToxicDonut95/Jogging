using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Infrastructure.Models;

[Table("School")]
public class School
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public List<Person> People { get; set; }
}