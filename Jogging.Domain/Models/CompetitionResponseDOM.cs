using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Domain.Models;

public class CompetitionResponseDOM
{
    [PrimaryKey]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    public DateTime? Date { get; set; }

    public int? AddressId { get; set; }
    public AddressResponseDOM AddressResponse { get; set; }

    public List<CompetitionPerCategoryResponseDOM> CompetitionPerCategories { get; set; }
}