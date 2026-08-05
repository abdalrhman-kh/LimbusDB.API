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
    public class SkillsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISkillsRepository skillsRepository;

        public SkillsController(IMapper mapper, ISkillsRepository skillsRepository)
        {
            this.mapper = mapper;
            this.skillsRepository = skillsRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] SkillsCreateRequestDTO skillsCreateRequestDTO) {
            var skillsDomain = mapper.Map<Skills>(skillsCreateRequestDTO);

            skillsDomain = await skillsRepository.CreateAsync(skillsDomain, skillsCreateRequestDTO.StatusEffectIds);

            var skillsDTO = mapper.Map<SkillsDTO>(skillsDomain);

            return Ok(skillsDTO);
        }

        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            var skillsDomain = await skillsRepository.GetAllAsync();

            var skillsDTO = mapper.Map<List<SkillsDTO>>(skillsDomain);

            return Ok(skillsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var skillsDomain = await skillsRepository.GetByIdAsync(id);

            if (skillsDomain == null)
                return NotFound();

            var skillsDTO = mapper.Map<SkillsDTO> (skillsDomain);

            return Ok(skillsDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SkillsEditRequestDTO skillsEditRequestDTO)
        {
            var skillsDomain = mapper.Map<Skills>(skillsEditRequestDTO);

            skillsDomain = await skillsRepository.UpdateAsync(id, skillsDomain, skillsEditRequestDTO.StatusEffectIds);

            if (skillsDomain == null)
                return NotFound();

            var skillsDTO = mapper.Map<SkillsDTO>(skillsDomain);

            return Ok(skillsDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var skillsDomain = await skillsRepository.GetByIdAsync(id);

            if (skillsDomain == null)
                return NotFound();

            skillsDomain = await skillsRepository.DeleteAsync(skillsDomain);

            var skillDTO = mapper.Map<SkillsDTO>(skillsDomain);

            return Ok(skillDTO);
        }
    }
}
