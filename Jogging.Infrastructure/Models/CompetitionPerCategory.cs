using Postgrest.Attributes;
using System.ComponentModel.DataAnnotations;
using Postgrest.Models;

namespace Jogging.Infrastructure.Models;

[Table("CompetitionPerCategory")]
public class CompetitionPerCategory: BaseModel
{
    [PrimaryKey]
    public int Id { get; set; }

    [Required]
    [Column("DistanceName")] 
    public string DistanceName { get; set; }

    [Column("DistanceInKm")] 
    public int DistanceInKm { get; set; }
    [Column("Gender")] 
    public char Gender { get; set; }

    [Column("AgeCategoryId")] 
    public int AgeCategoryId { get; set; }
    [Reference(typeof(AgeCategory), ReferenceAttribute.JoinType.Left)]
    public AgeCategory AgeCategory { get; set; }

    [Column("CompetitionId")] 
    public int CompetitionId { get; set; }
    [Reference(typeof(Competition), ReferenceAttribute.JoinType.Left)]
    public Competition Competition { get; set; }

    [Column("GunTime")] 
    public DateTime? GunTime { get; set; }

    [Reference(typeof(Registration), ReferenceAttribute.JoinType.Left)]
    public List<Registration> Registrations { get; set; }
}