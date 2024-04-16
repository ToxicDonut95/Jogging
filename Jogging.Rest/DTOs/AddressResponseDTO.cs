namespace Jogging.Rest.DTOs;

public class AddressResponseDTO
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }

    public List<PersonResponseDTO> People { get; set; }
    public List<CompetitionRequestDTO> Competitions { get; set; }
}