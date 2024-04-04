namespace Jogging.Rest.DTOs;

public class CompetitionPerCategoryDTO
{
    public int Id { get; set; }
    public string DistanceName { get; set; }

    public int DistanceInKm { get; set; }

    public char Gender { get; set; }

    public int AgeCategoryId { get; set; }
    public AgeCategoryDTO AgeCategory { get; set; }

    public int CompetitionId { get; set; }
    public CompetitionDTO Competition { get; set; }

    public DateTime? GunTime { get; set; }

    public List<RegistrationDTO> Registrations { get; set; }
}