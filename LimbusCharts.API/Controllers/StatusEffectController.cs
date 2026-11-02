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
    public class StatusEffectController : ControllerBase
    {
        private readonly IStatusEffectRepository statusEffectRepository;
        private readonly IMapper mapper;

        public StatusEffectController(IStatusEffectRepository statusEffectRepository, IMapper mapper)
        {
            this.statusEffectRepository = statusEffectRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] StatusEffectCreateRequestDTO statusEffectCreateRequestDTO)
        {
            var statusEffectDomain = mapper.Map<StatusEffect>(statusEffectCreateRequestDTO);

            await statusEffectRepository.CreateAsync(statusEffectDomain);

            var statusEffectDTO = mapper.Map<StatusEffectDTO>(statusEffectDomain);

            return Ok(statusEffectDTO);

        }
        [HttpGet]
        //[Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? StatusNameFillter, [FromQuery] bool? IsAscending)
        {
            var statusEffectDomain = await statusEffectRepository.GetAllAsync(StatusNameFillter, IsAscending ?? true);

            if (statusEffectDomain == null)
                return NotFound();

            var statusEffectDTO = mapper.Map<List<StatusEffectDTO>>(statusEffectDomain);

            return Ok(statusEffectDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var statusEffectDomain = await statusEffectRepository.GetByIdAsync(id);

            if (statusEffectDomain == null)
                return NotFound();

            var statusEffectDTO = mapper.Map<StatusEffectDTO>(statusEffectDomain);

            return Ok(statusEffectDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] StatusEffectEditRequestDTO statusEffectEditRequestDTO)
        {
            var statusEffectDomain = mapper.Map<StatusEffect>(statusEffectEditRequestDTO);

            statusEffectDomain = await statusEffectRepository.UpdateAsync(id, statusEffectDomain);

            var statusEffectDTO = mapper.Map<StatusEffectDTO>(statusEffectDomain);

            return Ok(statusEffectDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var statusEffectDomain = await statusEffectRepository.GetByIdAsync(id);

            if (statusEffectDomain == null)
                return NotFound();

            statusEffectDomain = await statusEffectRepository.DeleteAsync(statusEffectDomain);

            var statusEffectDTO = mapper.Map<StatusEffectDTO>(statusEffectDomain);

            return Ok(statusEffectDTO);
        }
    }
}
