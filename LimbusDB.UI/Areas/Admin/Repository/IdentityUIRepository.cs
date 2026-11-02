using System.Net.Http.Headers;
using LimbusDB.UI.Areas.Admin.Repository.IRepository;
using LimbusDB.UI.Models.DTO;
using LimbusDB.UI.Models.ViewModels;

namespace LimbusDB.UI.Areas.Admin.Repository
{
    public class IdentityUIRepository : IIdentityUIRepository
    {
        private readonly IHttpClientFactory http;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContext;

        public IdentityUIRepository(IHttpClientFactory http, IConfiguration configuration, IHttpContextAccessor httpContext)
        {
            this.http = http;
            this.configuration = configuration;
            this.httpContext = httpContext;
        }

        private HttpClient CreateClientWithToken()
        {
            var token = httpContext.HttpContext.Request.Cookies["jwt"];
            var client = http.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }

        public async Task<IEnumerable<RarityViewModel>> GetRarityAsync()
        {
            try
            {
                var client = CreateClientWithToken();
                var response = await client.GetAsync($"{configuration["LimbusAPI:BaseURL"]}/Rarity");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<RarityViewModel>>();
            }
            catch (Exception ex)
            {
                return new List<RarityViewModel>();
            }

        }

        public async Task<IEnumerable<SeasonViewModel>> GetSeasonAsync()
        {
            try
            {
                var client = CreateClientWithToken();
                var response = await client.GetAsync($"{configuration["LimbusAPI:BaseURL"]}/Season");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<SeasonViewModel>>();
            }
            catch (Exception ex)
            {
                return new List<SeasonViewModel>();
            }
        }

        public async Task<IEnumerable<SinnerViewModel>> GetSinnersAsync()
        {
            try
            {
                var client = CreateClientWithToken();
                var response = await client.GetAsync($"{configuration["LimbusAPI:BaseURL"]}/Sinner");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<SinnerViewModel>>();
            }
            catch (Exception ex)
            {
                return new List<SinnerViewModel>();
            }
        }

        public async Task<IEnumerable<StaggerThresholdViewModel>> GetStaggerAsync()
        {
            try
            {
                var client = CreateClientWithToken();
                var response = await client.GetAsync($"{configuration["LimbusAPI:BaseURL"]}/StaggerThreshold");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<StaggerThresholdViewModel>>();
            }
            catch (Exception ex)
            {
                return new List<StaggerThresholdViewModel>();
            }
        }

        public async Task<IEnumerable<StatusEffectViewModel>> GetStatusEffectsAsync()
        {
            try
            {
                var client = CreateClientWithToken();
                var response = await client.GetAsync($"{configuration["LimbusAPI:BaseURL"]}/StatusEffect");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<StatusEffectViewModel>>();
            }
            catch (Exception ex)
            {
                return new List<StatusEffectViewModel>();
            }
        }

        public async Task<IEnumerable<TraitKeyWordViewModel>> GetTraitKeywordsAsync()
        {
            try
            {
                var client = CreateClientWithToken();
                var response = await client.GetAsync($"{configuration["LimbusAPI:BaseURL"]}/TraitKeyword");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<TraitKeyWordViewModel>>();
            }
            catch (Exception ex)
            {
                return new List<TraitKeyWordViewModel>();
            }
        }

        public async Task<IEnumerable<IdentityViewModel>> GetIdentitiesAsync()
        {
            try
            {
                var client = CreateClientWithToken();
                var response = await client.GetAsync($"{configuration["LimbusAPI:BaseURL"]}/Identity");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<IdentityViewModel>>();
            }
            catch (Exception ex)
            {
                return new List<IdentityViewModel>();
            }
        }
    }
}
