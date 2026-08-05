using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IUpTieRepository
    {
        public Task<UpTie> CreateAsync(UpTie upTie);

        public Task<List<UpTie>> GetAllAsync();

        public Task<UpTie?> GetByIdAsync(Guid id);

        public Task<UpTie?> UpdateAsync(Guid id, UpTie upTie);

        public Task<UpTie?> DeleteAsync(UpTie upTie);
    }
}
