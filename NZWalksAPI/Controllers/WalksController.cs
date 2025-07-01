using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _repository;

        public WalksController(IMapper mapper, IWalkRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkDTO addWalkdto)
        {
            var walkDomain = _mapper.Map<Walk>(addWalkdto);
           await _repository.CreateAsync(walkDomain);

           var walkDto = _mapper.Map<WalkDTO>(walkDomain);
           return Ok(walkDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? criteria,
            [FromQuery] string? sortBy, [FromQuery] bool isAscending = true)
        {
            var walks = await _repository.GetAllWalksAsync(filterOn, criteria,sortBy,isAscending);

            var walksDto = _mapper.Map<List<WalkDTO>>(walks);

            return Ok(walksDto);
        }
    }
}
