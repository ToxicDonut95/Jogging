namespace Jogging.Rest.DTOs;

public class RegistrationDTO
{
    public int Id { get; set; }

    public short? RunNumber { get; set; }

    public DateTime? FinishTime { get; set; }

    public int CompetitionPerCategoryId { get; set; }
    public CompetitionPerCategoryDTO CompetitionPerCategory { get; set; }
}