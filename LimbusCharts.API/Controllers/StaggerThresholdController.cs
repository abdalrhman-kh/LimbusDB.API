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
    public class StaggerThresholdController : ControllerBase
    {
        private readonly IStaggerThresholdRepository staggerThresholdRepository;
        private readonly IMapper mapper;

        public StaggerThresholdController(IStaggerThresholdRepository staggerThresholdRepository, IMapper mapper)
        {
            this.staggerThresholdRepository = staggerThresholdRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] StaggerThresholdCreateRequestDTO staggerThresholdCreateRequest) {

            var staggerThresholdDomain = mapper.Map<StaggerThreshold>(staggerThresholdCreateRequest);

            staggerThresholdDomain = await staggerThresholdRepository.CreateAsync(staggerThresholdDomain);

            var staggerThresholdDTO = mapper.Map<StaggerThresholdDTO>(staggerThresholdDomain);

            return Ok(staggerThresholdDTO);
        }

        [HttpGet]
        //[Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            var staggerThresholdDomain = await staggerThresholdRepository.GallAllAsync();

            var staggerThresholdDTO = mapper.Map<List<StaggerThresholdDTO>>(staggerThresholdDomain);

            return Ok(staggerThresholdDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var staggerThresholdDomain = await staggerThresholdRepository.GetByIdAsync(id);

            if(staggerThresholdDomain == null)
                return NotFound();

            var staggerThresholdDTO = mapper.Map<StaggerThresholdDTO>(staggerThresholdDomain);

            return Ok(staggerThresholdDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] StaggerThresholdEditRequestDTO staggerThresholdEditRequestDTO)
        {
            var staggerThresholdDomain = mapper.Map<StaggerThreshold>(staggerThresholdEditRequestDTO);

            staggerThresholdDomain = await staggerThresholdRepository.UpdateAsync(id, staggerThresholdDomain);

            if (staggerThresholdDomain == null)
                return NotFound();

            var staggerThresholdDTO = mapper.Map<StaggerThresholdDTO>(staggerThresholdDomain);

            return Ok(staggerThresholdDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var staggerThresholdDomain = await staggerThresholdRepository.GetByIdAsync(id);

            if(staggerThresholdDomain == null)
                return NotFound();

            staggerThresholdDomain = await staggerThresholdRepository.DeleteAsync(staggerThresholdDomain);

            var staggerThresholdDTO = mapper.Map<StaggerThresholdDTO>(staggerThresholdDomain);

            return Ok(staggerThresholdDTO);
        }
    }
}
