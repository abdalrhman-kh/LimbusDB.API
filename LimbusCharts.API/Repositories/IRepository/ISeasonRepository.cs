using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface ISeasonRepository
    {
        public Task<Season> CreateAsync(Season season);

        public Task<List<Season>> GetAllAsync();

        public Task<Season?> GetByIdAsync(Guid id);

        public Task<Season?> UpdateAsync(Guid id, Season season);

        public Task<Season?> DeleteAsync(Season season);
    }
}
