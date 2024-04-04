using Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models
{
    public class Person : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [StringLength(30)]
        public string IBANNumber { get; set; }

        public int? SchoolId { get; set; }
        public School School { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public string UserId { get; set; }
    }
}
