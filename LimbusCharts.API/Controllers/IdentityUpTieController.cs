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
    public class IdentityUpTieController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IIdentityUptieRepository identityUpTieRepository;

        public IdentityUpTieController(IMapper mapper, IIdentityUptieRepository identityUpTieRepository)
        {
            this.mapper = mapper;
            this.identityUpTieRepository = identityUpTieRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IdentityUpTieCreateRequestDTO identityUpTieCreateRequestDTO)
        {
            var identityUpTieDomain = mapper.Map<IdentityUpTie>(identityUpTieCreateRequestDTO);

            identityUpTieDomain = await identityUpTieRepository.CreateAsync(identityUpTieDomain);

            var identityUpTieDTO = mapper.Map<IdentityUpTieDTO>(identityUpTieDomain);

            return Ok(identityUpTieDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var identityUpTieDomain = await identityUpTieRepository.GetAllAsync();

            var identityUpTieDTO = mapper.Map<List<IdentityUpTieDTO>>(identityUpTieDomain);

            return Ok(identityUpTieDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var identityUpTieDomain = await identityUpTieRepository.GetByIdAsync(id);

            if (identityUpTieDomain == null)
                return NotFound();

            var identityUpTieDTO = mapper.Map<IdentityUpTieDTO>(identityUpTieDomain);

            return Ok(identityUpTieDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] IdentityUpTieEditRequestDTO identityUpTieEditRequestDTO)
        {
            var identityUpTieDomain = mapper.Map<IdentityUpTie>(identityUpTieEditRequestDTO);

            identityUpTieDomain = await identityUpTieRepository.UpdateAsync(id, identityUpTieDomain);

            if (identityUpTieDomain == null)
                return NotFound();

            var identityUpTieDTO = mapper.Map<IdentityUpTieDTO>(identityUpTieDomain);

            return Ok(identityUpTieDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var identityUpTieDomain = await identityUpTieRepository.GetByIdAsync(id);

            if (identityUpTieDomain == null)
                return NotFound();

            identityUpTieDomain = await identityUpTieRepository.DeleteAsync(identityUpTieDomain);
            return Ok(identityUpTieDomain);
        }
    }
}
