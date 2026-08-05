using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class RarityRepository: IRarityRepository
    {
        private readonly DataDbContext context;

        public RarityRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<Rarity> CreateAsync(Rarity rarity)
        {
            await context.AddAsync(rarity);
            await context.SaveChangesAsync();
            return rarity;
        }

        public async Task<Rarity?> DeleteAsync(Rarity rarity)
        {
            context.Remove(rarity);
            await context.SaveChangesAsync();
            return rarity;
        }

        public async Task<List<Rarity>> GetAllAsync()
        {
            return await context.Rarity.ToListAsync();
        }

        public async Task<Rarity?> GetByIdAsync(Guid id)
        {
            return await context.Rarity.FirstOrDefaultAsync(x => x.RarityId == id);
        }

        public async Task<Rarity?> UpdateAsync(Guid id, Rarity rarity)
        {
            var oldRarity = await GetByIdAsync(id);

            if (oldRarity == null)
                return null;

            oldRarity.RarityType = rarity.RarityType;
            oldRarity.RarityImageURL = rarity.RarityImageURL;

            await context.SaveChangesAsync();
            return oldRarity;
        }
    }
}
