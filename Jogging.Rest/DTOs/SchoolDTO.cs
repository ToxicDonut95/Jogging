using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models;

public class SchoolDTO
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public List<PersonDTO> People { get; set; }
}