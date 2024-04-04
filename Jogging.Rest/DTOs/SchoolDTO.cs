namespace Jogging.Rest.DTOs;

public class SchoolDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<PersonDTO> People { get; set; }
}