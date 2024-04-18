using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Domain.Models;

public class CompetitionRequestDOM
{
    public string Name { get; set; }
    public DateTime? Date { get; set; }
    public bool Active { get; set; }
    public AddressResponseDOM AddressResponse { get; set; }

    public List<CompetitionPerCategoryResponseDOM> CompetitionPerCategories { get; set; }
}