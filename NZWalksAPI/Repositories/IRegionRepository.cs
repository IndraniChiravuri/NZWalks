using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories;

public interface IRegionRepository
{
    Task<List<Region>> GetAllRegionsAsync();
    Task<Region?> GetRegionByIdAsync(Guid id);

    Task<Region> CreateAsync(Region region);

    Task<Region?> UpdateAsync(Guid id,Region region);

    Task<Region?> DeleteAsync(Guid id);

    Task<List<Region>> DeleteAllRegionsAsync();
}