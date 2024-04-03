﻿using System.ComponentModel.DataAnnotations;

namespace Jogging.Infrastructure.Models;

public class CompetitionPerCategory
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string DistanceName { get; set; }

    public int DistanceInKm { get; set; }

    public char Gender { get; set; }

    public int AgeCategoryId { get; set; }
    public AgeCategory AgeCategory { get; set; }

    public int CompetitionId { get; set; }
    public Competition Competition { get; set; }

    public DateTime? GunTime { get; set; }

    public List<Registration> Registrations { get; set; }
}