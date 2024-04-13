using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;
using Postgrest.Models;

namespace Jogging.Infrastructure.Models;

[Table("Competition")]
public class Competition : BaseModel
{
    [PrimaryKey]
    public int Id { get; set; }

    [Required] 
    [Column("Name")] 
    public string Name { get; set; }
    [Column("Date")] 
    public DateTime? Date { get; set; }

    [Column("AddressId")] 
    public int? AddressId { get; set; }
    [Reference(typeof(Address), ReferenceAttribute.JoinType.Left)]
    public Address Address { get; set; }

    [Reference(typeof(CompetitionPerCategory), ReferenceAttribute.JoinType.Left)]
    public List<CompetitionPerCategory> CompetitionPerCategories { get; set; }
}