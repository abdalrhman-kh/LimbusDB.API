using System.Security.Claims;
using System.Text;
using System.Text.Json;
using LimbusDB.UI.Areas.Admin.Models.ViewModels;
using LimbusDB.UI.Models.AddViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LimbusDB.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory http;
        private readonly IConfiguration configuration;

        public AccountController(IHttpClientFactory http, IConfiguration configuration)
        {
            this.http = http;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                var Client = http.CreateClient();

                var httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{configuration["LimbusAPI:BaseURL"]}/Auth/Login"),
                    Content = new StringContent(JsonSerializer.Serialize(loginViewModel), Encoding.UTF8, "application/json")
                };

                var loginResponse = await Client.SendAsync(httpRequestMessage);

                loginResponse.EnsureSuccessStatusCode();

                var response = await loginResponse.Content.ReadFromJsonAsync<LoginResponseViewModel>();

                Response.Cookies.Append("jwt", response.JWTToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                });

                var claim = new List<Claim>
                {
                    new (ClaimTypes.Name, loginViewModel.UserName)
                };

                foreach(var role in response.Roles)
                {
                    claim.Add(new (ClaimTypes.Role, role));
                }

                var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Admin");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View(loginViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                var Client = http.CreateClient();

                var httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{configuration["LimbusAPI:BaseURL"]}/Register"),
                    Content = new StringContent(JsonSerializer.Serialize(registerViewModel), Encoding.UTF8, "application/json")
                };

                var loginResponse = await Client.SendAsync(httpRequestMessage);

                loginResponse.EnsureSuccessStatusCode();

                var loginRequest = new LoginViewModel
                {
                    UserName = registerViewModel.UserName,
                    Password = registerViewModel.Password,
                };

                return await Login(loginRequest);
            }

            catch
            {
                return View(registerViewModel);
            }
        }
    }
}
