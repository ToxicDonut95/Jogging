using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models
{
    public class PersonResponseDOM
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
        public SchoolResponseDOM SchoolResponse { get; set; }

        public int? AddressId { get; set; }
        public AddressResponseDOM AddressResponse { get; set; }

        public Guid? UserId { get; set; }
    }
}
