using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class UpTieRepository: IUpTieRepository
    {
        private readonly DataDbContext context;

        public UpTieRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<UpTie> CreateAsync(UpTie upTie)
        {
            await context.AddAsync(upTie);
            await context.SaveChangesAsync();
            return upTie;
        }

        public async Task<UpTie?> DeleteAsync(UpTie upTie)
        {
            context.Remove(upTie);
            await context.SaveChangesAsync();
            return upTie;
        }

        public async Task<List<UpTie>> GetAllAsync()
        {
            return await context.UpTie.ToListAsync();
        }

        public async Task<UpTie?> GetByIdAsync(Guid id)
        {
            return await context.UpTie.FirstOrDefaultAsync(x => x.UpTieId == id);
        }

        public async Task<UpTie?> UpdateAsync(Guid id, UpTie upTie)
        {
            var oldUpTie = await GetByIdAsync(id);

            if (oldUpTie == null)
                return null;

            oldUpTie.UpTieType = upTie.UpTieType;
            oldUpTie.UpTieImageURL = upTie.UpTieImageURL;

            await context.SaveChangesAsync();
            return oldUpTie;
        }
    }
}
