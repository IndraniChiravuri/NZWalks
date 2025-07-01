using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories;

public class SQLRegionRepository : IRegionRepository
{
    private readonly NZWalksDbContext _dbContext;

    public SQLRegionRepository(NZWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Region>> GetAllRegionsAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }

    public async Task<Region?> GetRegionByIdAsync(Guid id)
    {
        return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Region> CreateAsync(Region region)
    {
        await _dbContext.Regions.AddAsync(region);
        await _dbContext.SaveChangesAsync();

        return region;
    }

    public async Task<Region?> UpdateAsync(Guid id,Region region)
    {
        var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

        if (existingRegion == null) return null;

        existingRegion.Id = id;
        existingRegion.Code = region.Code;
        existingRegion.ImageUrl = region.ImageUrl;
        existingRegion.Name = region.Name;
        await _dbContext.SaveChangesAsync();

        return existingRegion;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion == null) return null;

        _dbContext.Regions.Remove(existingRegion);
        await _dbContext.SaveChangesAsync();

        return existingRegion;
    }

    public async Task<List<Region>> DeleteAllRegionsAsync()
    {
        var existingRegions = await _dbContext.Regions.ToListAsync();
        await _dbContext.Regions.ExecuteDeleteAsync();

        return existingRegions;
    }
}