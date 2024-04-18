using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class AgeCategoryRequestDOM
{
    public string Name { get; set; }

    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
}