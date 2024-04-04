namespace Jogging.Rest.DTOs;

public class AddressDTO
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }

    public List<PersonDTO> People { get; set; }
    public List<CompetitionDTO> Competitions { get; set; }
}