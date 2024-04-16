namespace Jogging.Rest.DTOs;

public class AgeCategoryRequestDTO
{
    public string Name { get; set; }

    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
}