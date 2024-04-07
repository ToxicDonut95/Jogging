using Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models;

public class Address : BaseModel
{
    [Key]
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }

    public List<Person> People { get; set; }
    public List<Competition> Competitions { get; set; }
}