using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class SchoolRequestDOM
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public List<PersonResponseDOM> People { get; set; }
}