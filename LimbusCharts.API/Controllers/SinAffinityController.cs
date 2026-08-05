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
    public class SinAffinityController : ControllerBase
    {
        private readonly ISinAffinityRepository sinAffinityRepository;
        private readonly IMapper mapper;

        public SinAffinityController(ISinAffinityRepository sinAffinityRepository, IMapper mapper)
        {
            this.sinAffinityRepository = sinAffinityRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] SinAffinityCreateRequestDTO sinAffinityCreateRequestDTO)
        {
            var sinAffinityDomain = mapper.Map<SinAffinity>(sinAffinityCreateRequestDTO);

            sinAffinityDomain = await sinAffinityRepository.CreateAsync(sinAffinityDomain);

            var sinAffinityDTO = mapper.Map<SinAffinityDTO>(sinAffinityDomain);

            return Ok(sinAffinityDTO);
        }

        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            var sinAffinityDomain = await sinAffinityRepository.GatAllAsync();

            var sinAffinityDTO = mapper.Map<List<SinAffinityDTO>>(sinAffinityDomain);

            return Ok(sinAffinityDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var sinAffinityDomain = await sinAffinityRepository.GetByIdAsync(id);

            if (sinAffinityDomain == null)
                return NotFound();

            var sinAffinityDTO = mapper.Map<SinAffinityDTO>(sinAffinityDomain);

            return Ok(sinAffinityDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SinAffinityEditRequestDTO sinAffinityEditRequestDTO)
        {
            var sinAffinityDomain = mapper.Map<SinAffinity>(sinAffinityEditRequestDTO);

            sinAffinityDomain = await sinAffinityRepository.UpdateAsync(id, sinAffinityDomain);

            if(sinAffinityDomain == null)
                return NotFound();

            var sinAffinityDTO = mapper.Map<SinAffinityDTO>(sinAffinityDomain);

            return Ok(sinAffinityDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var sinAffinityDomain = await sinAffinityRepository.GetByIdAsync(id);

            if( sinAffinityDomain == null)
                return NotFound();

            sinAffinityDomain = await sinAffinityRepository.DeleteAsync(sinAffinityDomain);

            var sinAffinityDTO = mapper.Map<SinAffinityDTO>(sinAffinityDomain);

            return Ok(sinAffinityDTO);
        }
    }
}
