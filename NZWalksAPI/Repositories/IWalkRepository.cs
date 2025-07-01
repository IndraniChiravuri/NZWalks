using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories;

public interface IWalkRepository
{
    Task<Walk> CreateAsync(Walk walk);

    Task<List<Walk>> GetAllWalksAsync(string? filterOn, string? criteria, string? sortBy, bool isAscending);
}