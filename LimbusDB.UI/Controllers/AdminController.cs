using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LimbusDB.UI.Models.AddViewModel;
using LimbusDB.UI.Models.DTO;
using LimbusDB.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LimbusDB.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory http;
        private readonly IConfiguration configuration;

        public AdminController(IHttpClientFactory http, IConfiguration configuration)
        {
            this.http = http;
            this.configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            List<IdentityViewModel> responce = new List<IdentityViewModel>();

            try
            {
                var client = http.CreateClient();

                var httpResponce = await client.GetAsync($"{configuration["LimbusAPI:BaseURl"]}/Identity");

                httpResponce.EnsureSuccessStatusCode();

                responce.AddRange(await httpResponce.Content.ReadFromJsonAsync<IEnumerable<IdentityViewModel>>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return View(responce);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateIdentityViewModel();

            try
            {
                var Client = http.CreateClient();

                var httpSinnerResponce = await Client.GetAsync($"{configuration["LimbusAPI:BaseURl"]}/Sinner");

                httpSinnerResponce.EnsureSuccessStatusCode();

                var sinners = await httpSinnerResponce.Content.ReadFromJsonAsync<IEnumerable<SinnerViewModel>>();

                if(sinners != null)
                    model.SinnerOptions = sinners.ToList();

                var httpRarityResponce = await Client.GetAsync($"{configuration["LimbusAPI:BaseURl"]}/Rarity");

                httpRarityResponce.EnsureSuccessStatusCode();

                var rarities = await httpRarityResponce.Content.ReadFromJsonAsync<IEnumerable<RarityViewModel>>();

                if (rarities != null)
                    model.RarityOptions = rarities.ToList();

                var httpUpTieResponce = await Client.GetAsync($"{configuration["LimbusAPI:BaseURl"]}/UpTie");

                httpUpTieResponce.EnsureSuccessStatusCode();

                var upTies = await httpUpTieResponce.Content.ReadFromJsonAsync<IEnumerable<IdentityUpTieViewModel>>();

                if(upTies != null)
                    model.UpTieOptions = upTies.ToList();

                var httpSeasonResponce = await Client.GetAsync($"{configuration["LimbusAPI:BaseURl"]}/Season");

                httpSeasonResponce.EnsureSuccessStatusCode();

                model.SeasonOptions = new SelectList(await httpSeasonResponce.Content.ReadFromJsonAsync<IEnumerable<SeasonViewModel>>(), "SeasonId", "SeasonNumber");

                var httpStatusResponce = await Client.GetAsync($"{configuration["LimbusAPI:BaseURl"]}/StatusEffect");

                httpStatusResponce.EnsureSuccessStatusCode();

                var statusEffects = await httpStatusResponce.Content.ReadFromJsonAsync<IEnumerable<StatusEffectViewModel>>();

                if(statusEffects != null)
                    model.statusEffectOptions = statusEffects.ToList();

                var httpTraitKeyWordResponce = await Client.GetAsync($"{configuration["LimbusAPI:BaseURl"]}/TraitKeyWord");

                httpTraitKeyWordResponce.EnsureSuccessStatusCode();

                model.traitKeywordOptions = new SelectList(await httpTraitKeyWordResponce.Content.ReadFromJsonAsync<IEnumerable<TraitKeyWordViewModel>>(), "Id", "TraitName");

                var httpStaggerWordResponce = await Client.GetAsync($"{configuration["LimbusAPI:BaseURl"]}/StaggerThreshold");

                httpStaggerWordResponce.EnsureSuccessStatusCode();

                model.StaggerOptions = new SelectList(await httpStaggerWordResponce.Content.ReadFromJsonAsync<IEnumerable<StaggerThresholdViewModel>>(), "Id", "Percentage");
            }

            catch (Exception ex)
            {
                return View(ex);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIdentityViewModel createIdentityViewModel)
        {
            try
            {
                var Client = http.CreateClient();

                var httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{configuration["LimbusAPI:BaseURL"]}/Identity"),
                    Content = new StringContent(JsonSerializer.Serialize(createIdentityViewModel), Encoding.UTF8, "application/json")
                };

                var httpResponce = await Client.SendAsync(httpRequestMessage);

                var error = await httpResponce.Content.ReadAsStringAsync();

                httpResponce.EnsureSuccessStatusCode();

                var responce = await httpResponce.Content.ReadFromJsonAsync<IdentityViewModel>();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create");
            }
        }
    }
}
