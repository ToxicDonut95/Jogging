using Postgrest.Attributes;
using Postgrest.Models;

namespace Jogging.Domain.Models;

public class CityDOM: BaseModel
{
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }
}