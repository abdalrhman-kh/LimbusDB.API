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
    public class UpTieController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUpTieRepository upTieRepository;

        public UpTieController(IMapper mapper, IUpTieRepository upTieRepository)
        {
            this.mapper = mapper;
            this.upTieRepository = upTieRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UpTieCreateRequestDTO upTieCreateRequestDTO)
        {
            var upTieDomain = mapper.Map<UpTie>(upTieCreateRequestDTO);

            upTieDomain = await upTieRepository.CreateAsync(upTieDomain);

            var upTieDTO = mapper.Map<UpTieDTO>(upTieDomain);

            return Ok(upTieDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var upTieDomain = await upTieRepository.GetAllAsync();

            var upTieDTO = mapper.Map<List<UpTieDTO>>(upTieDomain);

            return Ok(upTieDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var upTieDomain = await upTieRepository.GetByIdAsync(id);

            if (upTieDomain == null)
                return NotFound();

            var upTieDTO = mapper.Map<UpTieDTO>(upTieDomain);

            return Ok(upTieDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpTieEditRequestDTO upTieEditRequestDTO)
        {
            var upTieDomain = mapper.Map<UpTie>(upTieEditRequestDTO);

            upTieDomain = await upTieRepository.UpdateAsync(id, upTieDomain);

            if (upTieDomain == null)
                return NotFound();

            var upTieDTO = mapper.Map<UpTieDTO>(upTieDomain);

            return Ok(upTieDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var upTieDomain = await upTieRepository.GetByIdAsync(id);

            if (upTieDomain == null)
                return NotFound();

            upTieDomain = await upTieRepository.DeleteAsync(upTieDomain);
            return Ok(upTieDomain);
        }
    }
}
