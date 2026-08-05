using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class SinnerRepository : ISinnerRepository
    {
        private readonly DataDbContext context;

        public SinnerRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<Sinner> CreateAsync(Sinner sinner)
        {
            await context.AddAsync(sinner);
            await context.SaveChangesAsync();
            return sinner;
        }

        public async Task<Sinner?> DeleteAsync(Sinner sinner)
        {
            context.Remove(sinner);
            await context.SaveChangesAsync();
            return sinner;
        }

        public async Task<List<Sinner>> GetAllAsync()
        {
            return await context.Sinner.ToListAsync();
        }

        public async Task<Sinner?> GetByIdAsync(Guid id)
        {
            return await context.Sinner.FirstOrDefaultAsync(x => x.SinnerId == id);
        }

        public async Task<Sinner?> UpdateAsync(Guid id, Sinner sinner)
        {
            var oldSinner = await GetByIdAsync(id);

            if (oldSinner == null)
                return null;

            oldSinner.SinnerName = sinner.SinnerName;
            oldSinner.SinnerNumber = sinner.SinnerNumber;
            oldSinner.SinnerSymbolImageURL = sinner.SinnerSymbolImageURL;

            await context.SaveChangesAsync();
            return oldSinner;
        }
    }
}
