namespace Jogging.Rest.DTOs
{
    public class PersonResponseDTO
    {
        public int? Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? IBANNumber { get; set; }

        public int? SchoolId { get; set; }
        public SchoolResponseDTO? School { get; set; }

        public int? AddressId { get; set; }
        public AddressResponseDTO? Address { get; set; }

        public Guid? UserId { get; set; }
    }
}