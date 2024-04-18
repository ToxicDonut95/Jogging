using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class AddressRequestDOM
{
    public string Street { get; set; }
    public string City { get; set; }

    public List<PersonResponseDOM> People { get; set; }
    public List<CompetitionResponseDOM> Competitions { get; set; }
}