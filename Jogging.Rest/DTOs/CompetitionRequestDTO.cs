using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;

namespace Jogging.Rest.DTOs;

public class CompetitionRequestDTO
{
    public string Name { get; set; }
    public DateTime? Date { get; set; }
    public bool Active { get; set; }
    public AddressRequestDTO? Address { get; set; }
}