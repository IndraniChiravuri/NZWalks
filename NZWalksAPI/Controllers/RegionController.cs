using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/region")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;

        public RegionController(NZWalksDbContext dbContext, IMapper mapper, IRegionRepository regionRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllRegionsAsync();
            var regionsDto = _mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute]Guid id)
        {
            var region = await _regionRepository.GetRegionByIdAsync(id);
            var regionDto = _mapper.Map<RegionDTO>(region);
            if (regionDto == null)
            {
                return NotFound();
            }

            return Ok(regionDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO addRegionDTO)
        {
            var regionDomain = _mapper.Map<Region>(addRegionDTO);
            regionDomain = await _regionRepository.CreateAsync(regionDomain);
            var regionDto = _mapper.Map<RegionDTO>(regionDomain);
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPost]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDto)
        {
            var regionDomain = _mapper.Map<Region>(updateRegionDto);

            regionDomain = await _regionRepository.UpdateAsync(id,regionDomain);

            var regionDto = _mapper.Map<RegionDTO>(regionDomain);
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.DeleteAsync(id);
            var regionDto = _mapper.Map<RegionDTO>(regionDomain);
            return regionDto == null ? NotFound() : Ok(regionDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllRegions()
        {
            var regionDomain = await _regionRepository.DeleteAllRegionsAsync();
            var regionDto = _mapper.Map<List<RegionDTO>>(regionDomain);

            return Ok(regionDto);
        }

    }
}
