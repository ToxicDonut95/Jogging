using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models;

public class RegistrationDTO
{
    [Key]
    public int Id { get; set; }

    public short? RunNumber { get; set; }

    public DateTime? FinishTime { get; set; }

    public int CompetitionPerCategoryId { get; set; }
    public CompetitionPerCategoryDTO CompetitionPerCategory { get; set; }
}