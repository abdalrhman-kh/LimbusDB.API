using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class PassivesRepository : IPassivesRepository
    {
        private readonly DataDbContext context;

        public PassivesRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<Passives> CreateAsync(Passives passives, List<Guid> sinAffinityCountIds, List<Guid> statusEffectIds)
        {
            var sinAffinitiyCounts = await context.SinAffinityCount.Where(x => sinAffinityCountIds.Contains(x.Id)).ToListAsync();

            var statusEffects = await context.StatusEffect.Where(x => statusEffectIds.Contains(x.Id)).ToListAsync();

            var identity = await context.Identity.FirstOrDefaultAsync(x => x.Id == passives.IdentityId);

            passives.statusEffects = statusEffects;
            passives.SinAffinityCounts = sinAffinitiyCounts;
            passives.identity = identity;

            await context.Passives.AddAsync(passives);
            await context.SaveChangesAsync();
            return passives;
        }

        public async Task<Passives?> DeleteAsync(Passives passives)
        {
            context.Passives.Remove(passives);
            await context.SaveChangesAsync();
            return passives;
        }

        public async Task<List<Passives>> GetAllAsync()
        {
            return await context.Passives.ToListAsync();
        }

        public async Task<Passives?> GetByIdAsync(Guid id)
        {
            return await context.Passives.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Passives?> UpdateAsync(Guid id, Passives passives, List<Guid> sinAffinityCountIds, List<Guid> statusEffectIds)
        {
            var oldpassives = await GetByIdAsync(id);

            if (oldpassives == null)
                return null;

            var sinAffinityCounts = await context.SinAffinityCount.Where(x => sinAffinityCountIds.Contains(x.Id)).ToListAsync();

            var statusEffects = await context.StatusEffect.Where(x => statusEffectIds.Contains(x.Id)).ToListAsync();

            var identity = await context.Identity.FirstOrDefaultAsync(x => x.Id == passives.IdentityId);

            oldpassives.PassiveName = passives.PassiveName;
            oldpassives.PassiveDescription = passives.PassiveDescription;
            oldpassives.IdentityId = passives.IdentityId;

            oldpassives.identity = identity;

            if (oldpassives.SinAffinityCounts != null && sinAffinityCountIds != null) {
                oldpassives.SinAffinityCounts.Clear();
            }

            if(sinAffinityCountIds != null)
            {
                foreach(var sinAffinityCount in sinAffinityCounts)
                {
                    oldpassives.SinAffinityCounts.Add(sinAffinityCount);
                }
            }

            if (oldpassives.statusEffects != null && statusEffectIds != null)
            {
                oldpassives.statusEffects.Clear();
            }

            if (statusEffectIds != null)
            {
                foreach (var statusEffect in statusEffects)
                {
                    oldpassives.statusEffects.Add(statusEffect);
                }
            }

            await context.SaveChangesAsync();
            return oldpassives;
        }
    }
}
