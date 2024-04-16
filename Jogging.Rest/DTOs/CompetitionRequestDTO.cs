using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Rest.DTOs;

public class CompetitionRequestDTO
{
    [Required]
    public string Name { get; set; }
    public DateTime? Date { get; set; }

    public int? AddressId { get; set; }
    public AddressRequestDTO? Address { get; set; }
}