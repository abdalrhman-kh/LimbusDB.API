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
    public class RarityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRarityRepository rarityRepository;

        public RarityController(IMapper mapper, IRarityRepository rarityRepository)
        {
            this.mapper = mapper;
            this.rarityRepository = rarityRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RariryCreateRequestDTO rariryCreateRequestDTO)
        {
            var rarityDomain = mapper.Map<Rarity>(rariryCreateRequestDTO);

            rarityDomain = await rarityRepository.CreateAsync(rarityDomain);

            var rarityDTO = mapper.Map<RarityDTO>(rarityDomain);

            return Ok(rarityDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rarityDomain = await rarityRepository.GetAllAsync();

            var rarityDTO = mapper.Map<List<RarityDTO>>(rarityDomain);

            return Ok(rarityDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var rarityDomain = await rarityRepository.GetByIdAsync(id);

            if (rarityDomain == null)
                return NotFound();

            var rarityDTO = mapper.Map<RarityDTO>(rarityDomain);

            return Ok(rarityDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RarityEditRequestDTO rarityEditRequestDTO)
        {
            var rarityDomain = mapper.Map<Rarity>(rarityEditRequestDTO);

            rarityDomain = await rarityRepository.UpdateAsync(id, rarityDomain);

            if (rarityDomain == null)
                return NotFound();

            var rarityDTO = mapper.Map<RarityDTO>(rarityDomain);

            return Ok(rarityDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var rarityDomain = await rarityRepository.GetByIdAsync(id);

            if (rarityDomain == null)
                return NotFound();

            rarityDomain = await rarityRepository.DeleteAsync(rarityDomain);
            return Ok(rarityDomain);
        }
    }
}
