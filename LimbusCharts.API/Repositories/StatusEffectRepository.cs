using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class StatusEffectRepository : IStatusEffectRepository
    {
        private readonly DataDbContext context;

        public StatusEffectRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<StatusEffect?> CreateAsync(StatusEffect statusEffect)
        {
            await context.StatusEffect.AddAsync(statusEffect);
            await context.SaveChangesAsync();
            return statusEffect;
        }

        public async Task<StatusEffect?> DeleteAsync(StatusEffect statusEffect)
        {
            var fullStatusEffect = await context.StatusEffect.Include(x=>x.Identities).FirstOrDefaultAsync(x=>x.Id == statusEffect.Id);

            if (fullStatusEffect == null)
                return null;

            context.StatusEffect.Remove(fullStatusEffect);
            await context.SaveChangesAsync();
            return statusEffect;
        }

        public async Task<List<StatusEffect>> GetAllAsync(string? StatusNameFillter, bool IsAscending = true)
        {
            var statusEffectQuery = context.StatusEffect.Include(x=>x.Identities).AsQueryable();

            if (!String.IsNullOrEmpty(StatusNameFillter))
            {
                statusEffectQuery = statusEffectQuery.Where(x => x.StatusName.Contains(StatusNameFillter));
            }

            statusEffectQuery = IsAscending ? statusEffectQuery.OrderBy(x => x.StatusName): statusEffectQuery.OrderByDescending(x => x.StatusName);

            return await statusEffectQuery.ToListAsync();
        }

        public async Task<StatusEffect?> GetByIdAsync(Guid id)
        {
            return await context.StatusEffect.Include(x => x.Identities).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<StatusEffect?> UpdateAsync(Guid id, StatusEffect statusEffect)
        {
            var oldStatusEffect = await GetByIdAsync(id);

            if (oldStatusEffect == null)
                return null;

            oldStatusEffect.StatusName = statusEffect.StatusName;
            oldStatusEffect.StatusDescription = statusEffect.StatusDescription;
            oldStatusEffect.StatusImageURL = statusEffect.StatusImageURL;
           
            await context.SaveChangesAsync();
            return oldStatusEffect;

        }
    }
}
