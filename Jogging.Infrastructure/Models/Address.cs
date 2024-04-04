using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models;

public class Address
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Street { get; set; }

    [Required]
    [StringLength(100)]
    public string City { get; set; }

    public List<Person> People { get; set; }
    public List<Competition> Competitions { get; set; }
}