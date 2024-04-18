using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models;

public class SchoolRequestDOM
{
    public string Name { get; set; }

    public List<PersonResponseDOM> People { get; set; }
}