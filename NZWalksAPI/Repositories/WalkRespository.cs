using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories;

public class WalkRespository : IWalkRepository
{
    private readonly NZWalksDbContext _dbContext;

    public WalkRespository(NZWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _dbContext.Walks.AddAsync(walk);
        await _dbContext.SaveChangesAsync();

        return walk;
    }

    public async Task<List<Walk>> GetAllWalksAsync(string? filterOn, string? criteria, string? sortBy, bool isAscending = true)
    {
        var walks = _dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

        if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(criteria))
        {
            if (filterOn.Equals("Name", StringComparison.InvariantCultureIgnoreCase))
                walks = walks.Where(x => x.Name.Contains(criteria));
            if (filterOn.Equals("LengthInKm", StringComparison.InvariantCultureIgnoreCase))
            {
                var cr = double.Parse(criteria);
                walks = walks.Where(x => x.LengthInKm == cr);
            }
        }

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            if (sortBy.Equals("Name", StringComparison.InvariantCultureIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.Name) :
                walks.OrderByDescending(x => x.Name);
            }
            if (sortBy.Equals("LengthInKm", StringComparison.InvariantCultureIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.LengthInKm) :
                    walks.OrderByDescending(x => x.LengthInKm);
            }
        }

        return await walks.ToListAsync();
    }
}