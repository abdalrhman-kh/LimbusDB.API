using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class SinAffinityRepository : ISinAffinityRepository
    {
        private readonly DataDbContext context;

        public SinAffinityRepository(DataDbContext context)
        {
            this.context = context;
        }

        public async Task<SinAffinity> CreateAsync(SinAffinity sinAffinity)
        {
            await context.SinAffinity.AddAsync(sinAffinity);
            await context.SaveChangesAsync();
            return sinAffinity;
        }

        public async Task<SinAffinity?> DeleteAsync(SinAffinity sinAffinity)
        {
            context.SinAffinity.Remove(sinAffinity);
            await context.SaveChangesAsync();
            return sinAffinity;
        }

        public async Task<List<SinAffinity>> GatAllAsync()
        {
            return await context.SinAffinity.ToListAsync();
        }

        public async Task<SinAffinity?> GetByIdAsync(Guid id)
        {
            return await context.SinAffinity.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SinAffinity?> UpdateAsync(Guid id, SinAffinity sinAffinity)
        {
            var oldSinAffinity = await GetByIdAsync(id);

            if(oldSinAffinity == null)
                return null;

            oldSinAffinity.SinName = sinAffinity.SinName;
            oldSinAffinity.SinImageURL = sinAffinity.SinImageURL;

            await context.SaveChangesAsync();
            return sinAffinity;
        }
    }
}
