﻿using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models;

public class School
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public List<Person> People { get; set; }
}