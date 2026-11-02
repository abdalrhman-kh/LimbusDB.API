namespace LimbusCharts.API.Models.DTO
{
    public class LoginResponceDTO
    {
        public string JWTToken { get; set; }
        public List<string>? Roles { get; set; }
    }
}
