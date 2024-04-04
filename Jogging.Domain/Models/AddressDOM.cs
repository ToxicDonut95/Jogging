using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class AddressDOM
{
    [Key]
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }

    public List<PersonDOM> People { get; set; }
    public List<CompetitionDOM> Competitions { get; set; }
}