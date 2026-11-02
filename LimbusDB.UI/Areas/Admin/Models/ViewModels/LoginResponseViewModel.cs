namespace LimbusDB.UI.Areas.Admin.Models.ViewModels
{
    public class LoginResponseViewModel
    {
        public string JWTToken { get; set; }
        public List<string> Roles { get; set; }
    }
}
