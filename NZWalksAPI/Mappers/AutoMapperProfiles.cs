using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Mappers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<RegionDTO, Region>().ReverseMap();
        CreateMap<AddRegionDTO, RegionDTO>().ReverseMap();
        CreateMap<AddRegionDTO, Region>().ReverseMap();
        CreateMap<UpdateRegionDTO, Region>().ReverseMap();
        CreateMap<UpdateRegionDTO, RegionDTO>().ReverseMap();

        CreateMap<Walk, AddWalkDTO>().ReverseMap();
        CreateMap<Walk, WalkDTO>().ReverseMap();


        CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
    }
}