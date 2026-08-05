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
    public class PassivesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPassivesRepository passivesRepository;

        public PassivesController(IMapper mapper, IPassivesRepository passivesRepository)
        {
            this.mapper = mapper;
            this.passivesRepository = passivesRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] PassivesCreateRequestDTO passivesCreateRequestDTO)
        {
            var passivesDomain = mapper.Map<Passives>(passivesCreateRequestDTO);

            passivesDomain = await passivesRepository.CreateAsync(passivesDomain, passivesCreateRequestDTO.SinAffinityCountIds, passivesCreateRequestDTO.statusEffectIds);

            var passivesDTO = mapper.Map<PassivesDTO>(passivesDomain);

            return Ok(passivesDTO);
        }

        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            var passivesDomain = await passivesRepository.GetAllAsync();

            var passivesDTO = mapper.Map<List<PassivesDTO>>(passivesDomain);

            return Ok(passivesDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var passivesDomain = await passivesRepository.GetByIdAsync(id);

            if (passivesDomain == null)
                return NotFound();

            var passivesDTO = mapper.Map<PassivesDTO>(passivesDomain);

            return Ok(passivesDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PassivesEditRequestDTO passivesEditRequestDTO)
        {
            var passivesDomain = mapper.Map<Passives>(passivesEditRequestDTO);

            passivesDomain = await passivesRepository.UpdateAsync(id, passivesDomain, passivesEditRequestDTO.SinAffinityCountIds, passivesEditRequestDTO.statusEffectIds);

            if (passivesDomain == null)
                return NotFound();

            var passivesDTO = mapper.Map<PassivesDTO>(passivesDomain);

            return Ok(passivesDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var passivesDomain = await passivesRepository.GetByIdAsync(id);

            if(passivesDomain == null)
                return NotFound();

            passivesDomain = await passivesRepository.DeleteAsync(passivesDomain);

            var passivesDTO = mapper.Map<PassivesDTO>(passivesDomain);

            return Ok(passivesDTO);
        }
    }
}
