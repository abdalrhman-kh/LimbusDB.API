using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IRarityRepository
    {
        public Task<Rarity> CreateAsync(Rarity rarity);

        public Task<List<Rarity>> GetAllAsync();

        public Task<Rarity?> GetByIdAsync(Guid id);

        public Task<Rarity?> UpdateAsync(Guid id, Rarity rarity);

        public Task<Rarity?> DeleteAsync(Rarity rarity);
    }
}
