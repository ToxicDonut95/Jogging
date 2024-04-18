using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class CompetitionPerCategoryRequestDOM
{
    public string DistanceName { get; set; }

    public int DistanceInKm { get; set; }

    public char Gender { get; set; }

    public AgeCategoryResponseDOM AgeCategory { get; set; }

    public CompetitionResponseDOM CompetitionResponse { get; set; }

    public DateTime? GunTime { get; set; }

    public List<RegistrationResponseDOM> Registrations { get; set; }
}