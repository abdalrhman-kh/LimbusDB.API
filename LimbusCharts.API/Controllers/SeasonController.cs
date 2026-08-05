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
    public class SeasonController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISeasonRepository seasonRepository;

        public SeasonController(IMapper mapper, ISeasonRepository seasonRepository)
        {
            this.mapper = mapper;
            this.seasonRepository = seasonRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SeasonCreateRequestdTO seasonCreateRequestdTO)
        {
            var seasonDomain = mapper.Map<Season>(seasonCreateRequestdTO);

            seasonDomain = await seasonRepository.CreateAsync(seasonDomain);

            var seasonDTO = mapper.Map<SeasonDTO>(seasonDomain);

            return Ok(seasonDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seasonDomain = await seasonRepository.GetAllAsync();

            var seasonDTO = mapper.Map<List<SeasonDTO>>(seasonDomain);

            return Ok(seasonDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var seasonDomain = await seasonRepository.GetByIdAsync(id);

            if (seasonDomain == null)
                return NotFound();

            var seasonDTO = mapper.Map<SeasonDTO>(seasonDomain);

            return Ok(seasonDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SeasonEditRequestDTO seasonEditRequestDTO)
        {
            var seasonDomain = mapper.Map<Season>(seasonEditRequestDTO);

            seasonDomain = await seasonRepository.UpdateAsync(id, seasonDomain);

            if (seasonDomain == null)
                return NotFound();

            var seasonDTO = mapper.Map<SeasonDTO>(seasonDomain);

            return Ok(seasonDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var seasonDomain = await seasonRepository.GetByIdAsync(id);

            if (seasonDomain == null)
                return NotFound();

            seasonDomain = await seasonRepository.DeleteAsync(seasonDomain);
            return Ok(seasonDomain);
        }
    }
}
