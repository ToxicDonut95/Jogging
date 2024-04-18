namespace Jogging.Rest.DTOs;

public class CompetitionPerCategoryRequestDTO
{
    public string DistanceName { get; set; }

    public int DistanceInKm { get; set; }

    public char Gender { get; set; }

    public AgeCategoryResponseDTO AgeCategory { get; set; }

    public CompetitionRequestDTO Competition { get; set; }

    public DateTime? GunTime { get; set; }

    public List<RegistrationRequestDTO> Registrations { get; set; }
}