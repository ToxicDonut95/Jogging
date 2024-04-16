namespace Jogging.Rest.DTOs;

public class SchoolRequestDTO
{
    public string Name { get; set; }

    public List<PersonResponseDTO> People { get; set; }
}