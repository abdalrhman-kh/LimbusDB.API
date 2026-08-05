using Microsoft.AspNetCore.Identity;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IJWTTokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
