using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class RegistrationRequestDOM
{
    [Key]
    public int Id { get; set; }

    public short? RunNumber { get; set; }

    public DateTime? FinishTime { get; set; }

    public int CompetitionPerCategoryId { get; set; }
    public CompetitionPerCategoryResponseDOM CompetitionPerCategoryResponse { get; set; }
}