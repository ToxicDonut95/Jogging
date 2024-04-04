using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class SchoolDOM
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public List<PersonDOM> People { get; set; }
}