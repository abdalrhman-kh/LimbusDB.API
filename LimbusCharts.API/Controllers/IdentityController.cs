using AutoMapper;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Models.DTO;
using LimbusCharts.API.Models.DTO.CreateRequests;
using LimbusCharts.API.Models.DTO.EditRequests;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimbusCharts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IIdentityRepository identityRepository;

        public IdentityController(IMapper mapper, IIdentityRepository identityRepository)
        {
            this.mapper = mapper;
            this.identityRepository = identityRepository;
        }
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] IdentityCreateRequestDTO identityCreateRequestDTO)
        {
            //covert to domain
            var identityDomain = mapper.Map<Identity>(identityCreateRequestDTO);

            identityDomain = await identityRepository.CreateAsync(identityDomain, identityCreateRequestDTO.StatusEffectIds,
                identityCreateRequestDTO.TraitKeyWordIds, identityCreateRequestDTO.StaggerThresholdIds, identityCreateRequestDTO.IdentityUpTieIds);

            var IdentityDTO = mapper.Map<IdentityDTO> (identityDomain);

            return Ok(IdentityDTO);
        }

        [HttpGet]
        //[Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] int? season, [FromQuery] string? sinner, [FromQuery] int? rarity,
            [FromQuery] int? minSpeed, [FromQuery] int? maxSpeed, [FromQuery] string[]? statusEffect, [FromQuery] string? traitKeyword,
            [FromQuery] int? maxHealth, [FromQuery] int? defenseLevel, [FromQuery] double? slashResistance, [FromQuery] double? bluntResistance,
            [FromQuery] double? pierceResistance,[FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 15)
        {
            var identityDomain = await identityRepository.GetAllAsync(name, season, sinner, rarity, minSpeed, maxSpeed, statusEffect, traitKeyword, maxHealth, defenseLevel, 
                slashResistance, bluntResistance, pierceResistance, isAscending ?? true, pageNumber, pageSize);

            var identityDTO = mapper.Map<List<IdentityDTO>>(identityDomain);

            return Ok(identityDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var identityDomain = await identityRepository.GetByIdAsync(id);

            if (identityDomain == null)
                return NotFound();

            var identityDTO = mapper.Map<IdentityDTO>(identityDomain);

            return Ok(identityDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] IdentityEditRequestDTO identityEditRequestDTO) {

            var identityDomain = mapper.Map<Identity>(identityEditRequestDTO);

            identityDomain = await identityRepository.UpdateAsync(id, identityDomain,
                identityEditRequestDTO.StatusEffectIds, identityEditRequestDTO.TraitKeyWordIds, identityEditRequestDTO.StaggerThresholdIds, identityEditRequestDTO.IdentityUpTieIds);

            if (identityDomain == null)
                return NotFound();

            var identityDTO = mapper.Map<IdentityDTO>(identityDomain);
            return Ok(identityDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var identityDomain = await identityRepository.GetByIdAsync(id);

            if(identityDomain == null)
                return NotFound();

            identityDomain = await identityRepository.DeleteAsync(identityDomain);

            var identityDTO = mapper.Map<IdentityDTO>(identityDomain);

            return Ok(identityDTO);
        }
    }
}
