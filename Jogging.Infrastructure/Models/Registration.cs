using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models;

public class Registration
{
    [Key]
    public int Id { get; set; }

    public short RunNumber { get; set; }

    public DateTime? FinishTime { get; set; }

    public int CompetitionPerCategoryId { get; set; }
    public CompetitionPerCategory CompetitionPerCategory { get; set; }
}