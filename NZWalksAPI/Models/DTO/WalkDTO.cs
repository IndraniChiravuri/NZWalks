﻿using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Models.DTO;

public class WalkDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double LengthInKm { get; set; }

    public string? WalkImageUrl { get; set; }

    //public Guid DifficultyId { get; set; }

    //public Guid RegionId { get; set; }

    public DifficultyDTO Difficulty { get; set; }

    public RegionDTO Region { get; set; }
}