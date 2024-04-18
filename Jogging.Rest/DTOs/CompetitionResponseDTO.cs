using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Rest.DTOs;

public class CompetitionResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? Date { get; set; }
    public bool Active { get; set; }
    public int? AddressId { get; set; }
    public AddressResponseDTO? Address { get; set; }

    public List<CompetitionPerCategoryResponseDTO>? CompetitionPerCategories { get; set; }
}