using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class SinAffinityCountRepository : ISinAffinityCountRepository
    {
        private readonly DataDbContext context;

        public SinAffinityCountRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<SinAffinityCount> CreateAsync(SinAffinityCount sinAffinityCount)
        {
            var sinAffinity = await context.SinAffinity.FirstOrDefaultAsync(x => x.Id == sinAffinityCount.SinAffinityId);

            sinAffinityCount.sinAffinity = sinAffinity;

            await context.SinAffinityCount.AddAsync(sinAffinityCount);
            await context.SaveChangesAsync();
            return sinAffinityCount;
        }

        public async Task<SinAffinityCount?> DeleteAsync(SinAffinityCount sinAffinityCount)
        {
            context.SinAffinityCount.Remove(sinAffinityCount);
            await context.SaveChangesAsync();
            return sinAffinityCount;
        }

        public async Task<List<SinAffinityCount>> GetAllAsync()
        {
            return await context.SinAffinityCount.ToListAsync();
        }

        public async Task<SinAffinityCount?> GetByIdAsync(Guid id)
        {
            return await context.SinAffinityCount.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SinAffinityCount?> UpdateAsync(Guid id, SinAffinityCount sinAffinityCount)
        {
            var oldSinAffinityCount = await GetByIdAsync(id);

            if (oldSinAffinityCount == null)
                return null;

            var sinAffinity = await context.SinAffinity.FirstOrDefaultAsync(x => x.Id == sinAffinityCount.SinAffinityId);

            oldSinAffinityCount.sinAffinity = sinAffinity;

            oldSinAffinityCount.IsOwned = sinAffinityCount.IsOwned;
            oldSinAffinityCount.SinCount = sinAffinityCount.SinCount;

            await context.SaveChangesAsync();
            return oldSinAffinityCount;
        }
    }
}
