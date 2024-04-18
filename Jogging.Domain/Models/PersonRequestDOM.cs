using System.ComponentModel.DataAnnotations;

namespace Jogging.Domain.Models
{
    public class PersonRequestDOM
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public string? IBANNumber { get; set; }

        public SchoolRequestDOM School { get; set; }

        public AddressRequestDOM Address { get; set; }
    }
}