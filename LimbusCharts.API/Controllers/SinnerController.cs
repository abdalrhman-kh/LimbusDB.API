using AutoMapper;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Models.DTO;
using LimbusCharts.API.Models.DTO.CreateRequests;
using LimbusCharts.API.Models.DTO.EditRequests;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimbusCharts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinnerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISinnerRepository sinnerRepository;

        public SinnerController(IMapper mapper, ISinnerRepository sinnerRepository)
        {
            this.mapper = mapper;
            this.sinnerRepository = sinnerRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SinnerCreateRequestDTO sinnerCreateRequestDTO)
        {
            var sinnerDomain = mapper.Map<Sinner>(sinnerCreateRequestDTO);

            sinnerDomain = await sinnerRepository.CreateAsync(sinnerDomain);

            var sinnerDTO = mapper.Map<SinnerDTO>(sinnerDomain);

            return Ok(sinnerDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sinnerDomain = await sinnerRepository.GetAllAsync();

            var sinnerDTO = mapper.Map<List<SinnerDTO>>(sinnerDomain);

            return Ok(sinnerDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var sinnerDomain = await sinnerRepository.GetByIdAsync(id);

            if (sinnerDomain == null)
                return NotFound();

            var sinnerDTO = mapper.Map<SinnerDTO>(sinnerDomain);

            return Ok(sinnerDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SinnerEditRequestDTO sinnerEditRequestDTO)
        {
            var sinnerDomain = mapper.Map<Sinner>(sinnerEditRequestDTO);

            sinnerDomain = await sinnerRepository.UpdateAsync(id , sinnerDomain);

            if (sinnerDomain == null)
                return NotFound();

            var sinnerDTO = mapper.Map<SinnerDTO>(sinnerDomain);

            return Ok(sinnerDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var sinnerDomain = await sinnerRepository.GetByIdAsync(id);

            if(sinnerDomain == null)
                return NotFound();

            sinnerDomain = await sinnerRepository.DeleteAsync(sinnerDomain);
            return Ok(sinnerDomain);
        }
    }
}
