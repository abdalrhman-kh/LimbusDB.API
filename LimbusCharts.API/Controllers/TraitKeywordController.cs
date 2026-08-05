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
    public class TraitKeywordController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITraitKeywordRepository traitKeywordRepository;

        public TraitKeywordController(IMapper mapper, ITraitKeywordRepository traitKeywordRepository)
        {
            this.mapper = mapper;
            this.traitKeywordRepository = traitKeywordRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] TraitKeywordCreateRequestDTO traitKeywordCreateRequestDTO)
        {
            var traitKeywordDomain = mapper.Map<TraitKeyword>(traitKeywordCreateRequestDTO);

            traitKeywordDomain = await traitKeywordRepository.CreateAsync(traitKeywordDomain);

            var traitKeywordDTO = mapper.Map<TraitKeywordDTO>(traitKeywordDomain);

            return Ok(traitKeywordDTO);
        }

        [HttpGet]
        //[Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? TraitNameFillter, [FromQuery] bool? IsAscending)
        {
            var traitKeywordDomain = await traitKeywordRepository.GetAllAsync(TraitNameFillter, IsAscending ?? true);

            var traitKeywordDTO = mapper.Map<List<TraitKeywordDTO>>(traitKeywordDomain);

            return Ok(traitKeywordDTO);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var traitKeywordDomain = await traitKeywordRepository.GetByIdAsync(id);

            if (traitKeywordDomain == null)
                return NotFound();

            var traitKeywordDTO = mapper.Map<TraitKeywordDTO>(traitKeywordDomain);

            return Ok(traitKeywordDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TraitKeywordEditRequestDTO traitKeywordEditRequestDTO)
        {
            var traitKeywordDomain = mapper.Map<TraitKeyword>(traitKeywordEditRequestDTO);

            traitKeywordDomain = await traitKeywordRepository.UpdateAsync(id, traitKeywordDomain);

            if(traitKeywordDomain == null)
                return NotFound();

            var traitKeywordDTO = mapper.Map<TraitKeywordDTO>(traitKeywordDomain);

            return Ok(traitKeywordDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var traitKeywordDomain = await traitKeywordRepository.GetByIdAsync(id);

            if(traitKeywordDomain == null)
                return NotFound();

            traitKeywordDomain = await traitKeywordRepository.DeleteAsync(traitKeywordDomain);

            var traitKeywordDTO = mapper.Map<TraitKeywordDTO>(traitKeywordDomain);

            return Ok(traitKeywordDTO);
        }
    }
}
