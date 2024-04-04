using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class CompetitionPerCategoryDOM
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string DistanceName { get; set; }

    public int DistanceInKm { get; set; }

    public char Gender { get; set; }

    public int AgeCategoryId { get; set; }
    public AgeCategoryDOm AgeCategory { get; set; }

    public int CompetitionId { get; set; }
    public CompetitionDOM Competition { get; set; }

    public DateTime? GunTime { get; set; }

    public List<RegistrationDOM> Registrations { get; set; }
}