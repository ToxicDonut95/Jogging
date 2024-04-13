﻿using Postgrest.Attributes;
using Postgrest.Models;

namespace Jogging.Infrastructure.Models;

[Table("PersonRegistration")]
public class PersonRegistration : BaseModel
{
    [Column("PersonId")]
    public int PersonId { get; set; }
    //public Person Person { get; set; }
    [Column("RegistrationId")]
    public int RegistrationId { get; set; }
    //public Registration Registration { get; set; }

    public PersonRegistration()
    {
    }

    public PersonRegistration(int personId, int registrationId)
    {
        PersonId = personId;
        RegistrationId = registrationId;
    }
}