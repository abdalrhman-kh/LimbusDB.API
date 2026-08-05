using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class TraitKeywordRepository : ITraitKeywordRepository
    {
        private readonly DataDbContext context;

        public TraitKeywordRepository(DataDbContext context)
        {
            this.context = context;
        }

        public async Task<TraitKeyword> CreateAsync(TraitKeyword traitKeyword)
        {

            await context.TraitKeyword.AddAsync(traitKeyword);
            await context.SaveChangesAsync();
            return traitKeyword;
        }

        public async Task<TraitKeyword?> DeleteAsync(TraitKeyword traitKeyword)
        {
            context.TraitKeyword.Remove(traitKeyword);
            await context.SaveChangesAsync();
            return traitKeyword;
        }

        public async Task<List<TraitKeyword>> GetAllAsync(string? traitName, bool isAscending = true)
        {
            var traitKeywordQuery = context.TraitKeyword.Include(x => x.Identities).AsQueryable();

            if (!String.IsNullOrEmpty(traitName))
            {
                traitKeywordQuery = traitKeywordQuery.Where(x => x.TraitName.Contains(traitName));
            }

            traitKeywordQuery = isAscending ? traitKeywordQuery.OrderBy(x => x.TraitName) : traitKeywordQuery.OrderByDescending(x => x.TraitName);


            return await traitKeywordQuery.ToListAsync();
        }

        public async Task<TraitKeyword?> GetByIdAsync(Guid id)
        {
            return await context.TraitKeyword.Include(x => x.Identities).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TraitKeyword?> UpdateAsync(Guid id, TraitKeyword traitKeyword)
        {
            var oldTraitKeyword = await GetByIdAsync(id);

            if (oldTraitKeyword == null)
                return null;

            oldTraitKeyword.TraitName = traitKeyword.TraitName;

            await context.SaveChangesAsync();
            return oldTraitKeyword;
        }
    }
}
