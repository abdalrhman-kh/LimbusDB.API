using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LimbusDB.UI.Areas.Admin.Repository.IRepository;
using LimbusDB.UI.Models.AddViewModel;
using LimbusDB.UI.Models.DTO;
using LimbusDB.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LimbusDB.UI.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory http;
        private readonly IConfiguration configuration;
        private readonly IIdentityUIRepository identityUIRepository;

        public AdminController(IHttpClientFactory http, IConfiguration configuration, IIdentityUIRepository identityUIRepository)
        {
            this.http = http;
            this.configuration = configuration;
            this.identityUIRepository = identityUIRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<IdentityViewModel> response = new List<IdentityViewModel>();

            var identities = await identityUIRepository.GetIdentitiesAsync();

            response.AddRange(identities);

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateIdentityViewModel();

            model.SinnerOptions = (await identityUIRepository.GetSinnersAsync()).ToList();

            model.RarityOptions = (await identityUIRepository.GetRarityAsync()).ToList();

            model.SeasonOptions = new SelectList (await identityUIRepository.GetSeasonAsync(), "SeasonId", "SeasonNumber");

            model.statusEffectOptions = (await identityUIRepository.GetStatusEffectsAsync()).ToList();

            model.traitKeywordOptions = new SelectList(await identityUIRepository.GetTraitKeywordsAsync(), "Id", "TraitName");

            model.StaggerOptions = new SelectList(await identityUIRepository.GetStaggerAsync(), "Id", "Percentage");

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

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create");
            }
        }
    }
}
