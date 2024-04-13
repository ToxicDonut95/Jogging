namespace Jogging.Rest.DTOs
{
    public class PersonDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? IBANNumber { get; set; }

        public int? SchoolId { get; set; }

        public int? AddressId { get; set; }

        public Guid? UserId { get; set; }
    }
}