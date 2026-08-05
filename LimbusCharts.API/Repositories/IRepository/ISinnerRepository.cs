using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface ISinnerRepository
    {
        public Task<Sinner> CreateAsync(Sinner sinner);

        public Task<List<Sinner>> GetAllAsync();

        public Task<Sinner?> GetByIdAsync(Guid id);

        public Task<Sinner?> UpdateAsync(Guid id, Sinner sinner);

        public Task<Sinner?> DeleteAsync(Sinner sinner);
    }
}
