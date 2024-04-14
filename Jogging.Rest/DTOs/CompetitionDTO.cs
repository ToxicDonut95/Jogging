using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Rest.DTOs;

public class CompetitionDTO
{
    [PrimaryKey]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime? Date { get; set; }

    public int? AddressId { get; set; }
    public AddressDTO? Address { get; set; }

    public List<CompetitionPerCategoryDTO>? CompetitionPerCategories { get; set; }
}