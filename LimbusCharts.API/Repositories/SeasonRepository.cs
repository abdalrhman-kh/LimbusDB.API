using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class SeasonRepository: ISeasonRepository
    {
        private readonly DataDbContext context;

        public SeasonRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<Season> CreateAsync(Season season)
        {
            await context.AddAsync(season);
            await context.SaveChangesAsync();
            return season;
        }

        public async Task<Season?> DeleteAsync(Season season)
        {
            context.Remove(season);
            await context.SaveChangesAsync();
            return season;
        }

        public async Task<List<Season>> GetAllAsync()
        {
            return await context.Season.ToListAsync();
        }

        public async Task<Season?> GetByIdAsync(Guid id)
        {
            return await context.Season.FirstOrDefaultAsync(x => x.SeasonId == id);
        }

        public async Task<Season?> UpdateAsync(Guid id, Season season)
        {
            var oldSeason = await GetByIdAsync(id);

            if (oldSeason == null)
                return null;

            oldSeason.SeasonName = season.SeasonName;
            oldSeason.SeasonNumber = season.SeasonNumber;
            oldSeason.SeasonImageURL = season.SeasonImageURL;

            await context.SaveChangesAsync();
            return oldSeason;
        }
    }
}
