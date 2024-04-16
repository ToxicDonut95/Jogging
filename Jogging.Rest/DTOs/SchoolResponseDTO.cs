namespace Jogging.Rest.DTOs;

public class SchoolResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<PersonResponseDTO> People { get; set; }
}