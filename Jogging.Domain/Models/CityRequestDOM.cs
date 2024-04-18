using Postgrest.Attributes;
using Postgrest.Models;

namespace Jogging.Domain.Models;

public class CityRequestDOM: BaseModel
{
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
}