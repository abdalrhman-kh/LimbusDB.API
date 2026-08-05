using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class StaggerThresholdRepository : IStaggerThresholdRepository
    {
        private readonly DataDbContext context;

        public StaggerThresholdRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<StaggerThreshold> CreateAsync(StaggerThreshold staggerThreshold)
        {
            await context.StaggerThreshold.AddAsync(staggerThreshold);
            await context.SaveChangesAsync();
            return staggerThreshold;
        }

        public async Task<StaggerThreshold?> DeleteAsync(StaggerThreshold staggerThreshold)
        {


            context.StaggerThreshold.Remove(staggerThreshold);
            await context.SaveChangesAsync();
            return staggerThreshold;
        }

        public async Task<List<StaggerThreshold>> GallAllAsync()
        {
            return await context.StaggerThreshold.ToListAsync();
        }

        public async Task<StaggerThreshold?> GetByIdAsync(Guid id)
        {
            return await context.StaggerThreshold.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<StaggerThreshold?> UpdateAsync(Guid id, StaggerThreshold staggerThreshold)
        {
            var oldStaggerThreshold = await GetByIdAsync(id);

            if (oldStaggerThreshold == null)
                return null;

            oldStaggerThreshold.Percentage = staggerThreshold.Percentage;

            await context.SaveChangesAsync();
            return staggerThreshold;
        }
    }
}
