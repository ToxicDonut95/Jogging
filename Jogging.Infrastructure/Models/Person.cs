using Postgrest.Attributes;
using Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models
{
    [Table("Person")]
    public class Person : BaseModel
    {
        [PrimaryKey("Id", false)]
        public int Id { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }

        [Column("IBANNumber")]
        public string IBANNumber { get; set; }

        [Column("SchoolId")]
        public int? SchoolId { get; set; }

        //public School School { get; set; }

        [Column("AdressId")]
        public int? AddressId { get; set; }

        //public Address Address { get; set; }

        [Column("UserId")]
        public string UserId { get; set; }
    }
}