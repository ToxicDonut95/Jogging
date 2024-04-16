namespace Jogging.Rest.DTOs;

public class CompetitionPerCategoryRequestDTO
{
    public string DistanceName { get; set; }

    public int DistanceInKm { get; set; }

    public char Gender { get; set; }

    public int AgeCategoryId { get; set; }
    public AgeCategoryResponseDTO AgeCategoryResponse { get; set; }

    public int CompetitionId { get; set; }
    public CompetitionRequestDTO CompetitionRequest { get; set; }

    public DateTime? GunTime { get; set; }

    public List<RegistrationRequestDTO> Registrations { get; set; }
}