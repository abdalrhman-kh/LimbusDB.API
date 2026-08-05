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
    public class SinAffinityCountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISinAffinityCountRepository sinAffinityCountRepository;

        public SinAffinityCountController(IMapper mapper, ISinAffinityCountRepository sinAffinityCountRepository)
        {
            this.mapper = mapper;
            this.sinAffinityCountRepository = sinAffinityCountRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] SinAffinityCoutCreateRequestDTO sinAffinityCoutCreateRequestDTO)
        {
            var sinAffinityCountDomain = mapper.Map<SinAffinityCount>(sinAffinityCoutCreateRequestDTO);

            sinAffinityCountDomain = await sinAffinityCountRepository.CreateAsync(sinAffinityCountDomain);

            var sinAffinityCountDTO = mapper.Map<SinAffinityCountDTO>(sinAffinityCountDomain);

            return Ok(sinAffinityCountDTO);
        }

        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            var sinAffinityCountDomain = await sinAffinityCountRepository.GetAllAsync();

            var sinAffinityCountDTO = mapper.Map<List<SinAffinityCountDTO>>(sinAffinityCountDomain);

            return Ok(sinAffinityCountDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var sinAffinityCountDomain = await sinAffinityCountRepository.GetByIdAsync(id);

            if (sinAffinityCountDomain == null)
                return NotFound();

            var sinAffinityCountDTO = mapper.Map<SinAffinityCountDTO>(sinAffinityCountDomain);

            return Ok(sinAffinityCountDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SinAffinityCountEditRequestDTO sinAffinityCountEditRequestDTO) {
            var sinAffinityCountDomain = mapper.Map<SinAffinityCount>(sinAffinityCountEditRequestDTO);

            sinAffinityCountDomain = await sinAffinityCountRepository.UpdateAsync(id, sinAffinityCountDomain);

            if (sinAffinityCountDomain == null)
                return NotFound();

            var sinAffinityDTO = mapper.Map<SinAffinityCountDTO>(sinAffinityCountDomain);

            return Ok(sinAffinityDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var sinAffinityCountDomain = await sinAffinityCountRepository.GetByIdAsync(id);

            if (sinAffinityCountDomain == null)
                return NotFound();

            sinAffinityCountDomain = await sinAffinityCountRepository.DeleteAsync(sinAffinityCountDomain);

            var sinAffinityCountDTO = mapper.Map<SinAffinityCountDTO>(sinAffinityCountDomain);

            return Ok(sinAffinityCountDTO);
        }
    }
}
