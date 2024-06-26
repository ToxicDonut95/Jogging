﻿namespace Jogging.Rest.DTOs
{
    public class PersonRequestDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? IBANNumber { get; set; }

        public SchoolRequestDTO? School { get; set; }

        public AddressRequestDTO? Address { get; set; }
    }
}