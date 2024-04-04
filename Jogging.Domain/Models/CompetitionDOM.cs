using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class CompetitionDOM
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    public DateTime? Date { get; set; }

    public int? AddressId { get; set; }
    public AddressDOM Address { get; set; }

    public List<CompetitionPerCategory> CompetitionPerCategories { get; set; }
}