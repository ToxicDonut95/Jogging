namespace Jogging.Rest.DTOs;

public class CompetitionDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? Date { get; set; }

    public int? AddressId { get; set; }
    public AddressDTO Address { get; set; }

    public List<CompetitionPerCategoryDTO> CompetitionPerCategories { get; set; }
}