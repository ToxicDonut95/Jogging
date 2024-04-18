using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class RegistrationRequestDOM
{
    public short? RunNumber { get; set; }

    public DateTime? FinishTime { get; set; }

    public CompetitionPerCategoryResponseDOM CompetitionPerCategoryResponse { get; set; }
}