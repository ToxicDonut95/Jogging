using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Infrastructure.Models;

[Table("AgeCategory")]
public class AgeCategory
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
}