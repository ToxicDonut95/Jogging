using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;
using Postgrest.Models;

namespace Jogging.Infrastructure.Models
{
    [Table("Person")]
    public class Person : BaseModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }

        [Column("IBANNumber")]
        public string IBANNumber { get; set; }

        [Column("SchoolId")]
        public int? SchoolId { get; set; }
        [Reference(typeof(School), ReferenceAttribute.JoinType.Left)]
        public School School { get; set; }

        [Column("AddressId")]
        public int? AddressId { get; set; }
        [Reference(typeof(Address), ReferenceAttribute.JoinType.Left)]
        public Address Address { get; set; }

        [Column("UserId")]
        public string UserId { get; set; }
    }
}
