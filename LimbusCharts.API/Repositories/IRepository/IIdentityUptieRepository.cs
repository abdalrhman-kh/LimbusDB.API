using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IIdentityUptieRepository
    {
        public Task<IdentityUpTie> CreateAsync(IdentityUpTie uptie);

        public Task<List<IdentityUpTie>> GetAllAsync();

        public Task<IdentityUpTie?> GetByIdAsync(Guid id);

        public Task<IdentityUpTie?> UpdateAsync(Guid id, IdentityUpTie uptie);

        public Task<IdentityUpTie?> DeleteAsync(IdentityUpTie uptie);
    }
}
