using Postgrest.Attributes;
using Postgrest.Models;

namespace Jogging.Infrastructure.Models;

[Table("Registration")]
public class Registration : BaseModel
{
    [PrimaryKey("Id", false)]
    public int Id { get; set; }

    [Column("RunNumber")]
    public short? RunNumber { get; set; }

    [Column("FinishTime")]
    public DateTime? FinishTime { get; set; }

    [Column("CompetitionPerCategoryId")]
    public int CompetitionPerCategoryId { get; set; }

    //public CompetitionPerCategory CompetitionPerCategory { get; set; }
}