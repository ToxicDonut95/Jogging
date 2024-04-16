using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class AddressRequestDOM
{
    [Key]
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }

    public List<PersonResponseDOM> People { get; set; }
    public List<CompetitionResponseDOM> Competitions { get; set; }
}