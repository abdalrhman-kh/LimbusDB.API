using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class IdentityRepository: IIdentityRepository
    {
        private readonly DataDbContext context;

        public IdentityRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Identity>> GetAllAsync(string? name, int? season, string? sinner, int? rarity,
            int? minSpeed, int? maxSpeed, string[]? statusEffect, string? traitKeyword, int? maxHealth, int? defenseLevel,
            double? slashResistance, double? bluntResistance, double? pierceResistance,
            bool isAscending = false, int pageNumber = 1, int pageSize = 15)
        {
            var identityQuery = context.Identity.Include(x => x.StatusEffects).Include(x => x.TraitKeywords).Include(x => x.StaggerThresholds)
                .Include(x => x.Sinner).Include(x => x.Rarity).Include(x => x.IdentityUpTies).Include(x => x.Season).AsQueryable();

            if (!String.IsNullOrEmpty(name))
            {
                identityQuery = identityQuery.Where(x => x.IdentityName.Contains(name));
            }

            if (!String.IsNullOrEmpty(sinner))
            {
                identityQuery = identityQuery.Where(x => x.Sinner.SinnerName == sinner);
            }

            if (rarity.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.Rarity.RarityType == rarity);
            }

            if (minSpeed.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.IdentityUpTies.Any(u => u.MinSpeed == minSpeed));
            }

            if (maxSpeed.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.IdentityUpTies.Any(u => u.MaxSpeed == maxSpeed));
            }

            if (season.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.Season.SeasonNumber == season);
            }

            foreach(var status in statusEffect)
            {
                identityQuery = identityQuery.Where(x => x.StatusEffects.Any(s => s.StatusName == status));
            }

            //if (!String.IsNullOrEmpty(statusEffect))
            //{
            //    identityQuery = identityQuery.Where(x => x.StatusEffects.Any(s => s.StatusName == statusEffect));
            //}

            if (!String.IsNullOrEmpty(traitKeyword))
            {
                identityQuery = identityQuery.Where(x => x.TraitKeywords.Any(t => t.TraitName == traitKeyword));
            }

            if (maxHealth.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.MaxHealth == maxHealth);
            }

            if (defenseLevel.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.DefenseLevel == defenseLevel);
            }

            if (slashResistance.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.SlashResistance == slashResistance);
            }

            if (bluntResistance.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.BluntResistance == bluntResistance);
            }

            if (pierceResistance.HasValue)
            {
                identityQuery = identityQuery.Where(x => x.PierceResistance == pierceResistance);
            }

            identityQuery = isAscending ? identityQuery.OrderBy(x => x.ReleaseDate): identityQuery.OrderByDescending(x => x.ReleaseDate);

            var skipResults = (pageNumber - 1) * pageSize;

            return await identityQuery.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Identity?> GetByIdAsync(Guid id)
        {
            return await context.Identity.Include(x => x.Sinner).Include(x => x.Rarity).Include(x => x.IdentityUpTies).Include(x => x.Season).Include(x => x.StatusEffects)
                .Include(x => x.TraitKeywords).Include(x => x.StaggerThresholds).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Identity> CreateAsync(Identity identity, List<Guid> statusEffectIds, List<Guid> traitKeywordIds, List<Guid> staggerThresholdIds, List<Guid> IdentityUpTieIds)
        {
            var statusEffects = await context.StatusEffect.Where(x => statusEffectIds.Contains(x.Id)).ToListAsync();

            var traitKeywords = await context.TraitKeyword.Where(x => traitKeywordIds.Contains(x.Id)).ToListAsync();

            var staggerThresholds = await context.StaggerThreshold.Where(x => staggerThresholdIds.Contains(x.Id)).ToListAsync();

            var IdentityUpTies = await context.IdentityUpTie.Where(x => IdentityUpTieIds.Contains(x.IdentityUpTieId)).ToListAsync();

            var sinner = await context.Sinner.FirstOrDefaultAsync(x => x.SinnerId == identity.SinnerId);
            var rarity = await context.Rarity.FirstOrDefaultAsync(x => x.RarityId == identity.RarityId);
            var season = await context.Season.FirstOrDefaultAsync(x => x.SeasonId == identity.SeasonId);

            identity.StatusEffects = statusEffects;
            identity.TraitKeywords = traitKeywords;
            identity.StaggerThresholds = staggerThresholds;
            identity.IdentityUpTies = IdentityUpTies;
            identity.Sinner = sinner;
            identity.Rarity = rarity;
            identity.Season = season;

            await context.Identity.AddAsync(identity);
            await context.SaveChangesAsync();
            return identity;
        }
        public async Task<Identity?> UpdateAsync(Guid id, Identity identity, List<Guid> statusEffectIds, List<Guid> traitKeywordIds, List<Guid> staggerThresholdIds,
            List<Guid> IdentityUpTieIds)
        {
            var oldIdentity = await GetByIdAsync(id);

            if (oldIdentity == null)
                return null;

            var statusEffects = await context.StatusEffect.Where(x => statusEffectIds.Contains(x.Id)).ToListAsync();

            var traitKeywords = await context.TraitKeyword.Where(x => traitKeywordIds.Contains(x.Id)).ToListAsync();

            var staggerThresholds = await context.StaggerThreshold.Where(x => staggerThresholdIds.Contains(x.Id)).ToListAsync();

            var UpTies = await context.IdentityUpTie.Where(x => IdentityUpTieIds.Contains(x.IdentityUpTieId)).ToListAsync();
            //update identity stats
            oldIdentity.IdentityName = identity.IdentityName;
            oldIdentity.MaxHealth = identity.MaxHealth;
            oldIdentity.SlashResistance = identity.SlashResistance;
            oldIdentity.BluntResistance = identity.BluntResistance;
            oldIdentity.PierceResistance = identity.PierceResistance;
            oldIdentity.DefenseLevel = identity.DefenseLevel;
            oldIdentity.UpTieImage_1 = identity.UpTieImage_1;
            oldIdentity.UpTieImage_2 = identity.UpTieImage_2;
            oldIdentity.ReleaseDate = identity.ReleaseDate;
            //finish updating identity stats

            //update identity sinner
            oldIdentity.Sinner.SinnerName = identity.Sinner.SinnerName;
            oldIdentity.Sinner.SinnerNumber = identity.Sinner.SinnerNumber;
            oldIdentity.Sinner.SinnerSymbolImageURL = identity.Sinner.SinnerSymbolImageURL;
            //finish updating identity sinner

            //update identity rarity
            oldIdentity.Rarity.RarityType = identity.Rarity.RarityType;
            oldIdentity.Rarity.RarityImageURL = identity.Rarity.RarityImageURL;
            //finish updating identity rarity

            //update identity season
            oldIdentity.Season.SeasonName = identity.Season.SeasonName;
            oldIdentity.Season.SeasonNumber = identity.Season.SeasonNumber;
            oldIdentity.Season.SeasonImageURL  = identity.Season.SeasonImageURL;
            //finish updating identity season

            //update identity statues effects
            oldIdentity.StatusEffects = new List<StatusEffect>();
            oldIdentity.StatusEffects.Clear();

            if (statusEffects != null)
            {
                foreach (var effect in statusEffects)
                {
                    oldIdentity.StatusEffects.Add(effect);
                }
            }
            //finish updating identity statues effects

            //update identity trait key word
            oldIdentity.TraitKeywords ??= new List<TraitKeyword>();
            oldIdentity.TraitKeywords.Clear();

            if (traitKeywords != null)
            {
                foreach (var trait in traitKeywords)
                {
                    oldIdentity.TraitKeywords.Add(trait);
                }
            }
            //finish updating identity trait key word

            //update identity stagger threshold
            oldIdentity.StaggerThresholds ??= new List<StaggerThreshold>();
            oldIdentity.StaggerThresholds.Clear();

            if (staggerThresholds != null)
            {
                foreach (var staggerThreshold in staggerThresholds)
                {
                    oldIdentity.StaggerThresholds.Add(staggerThreshold);
                }
            }
            //finsish updating identity stagger threshold

            //update identity UpTie
            oldIdentity.IdentityUpTies ??= new List<IdentityUpTie>();
            oldIdentity.IdentityUpTies.Clear();

            if (UpTies != null)
            {
                foreach (var UpTie in UpTies)
                {
                    oldIdentity.IdentityUpTies.Add(UpTie);
                }
            }
            //finsish updating identity UpTie

            await context.SaveChangesAsync();
            return oldIdentity;
        }

        public async Task<Identity?> DeleteAsync(Identity identity)
        {
            var fullIdentity = await context.Identity.Include(x => x.StatusEffects).Include(x => x.TraitKeywords).FirstOrDefaultAsync(x=>x.Id == identity.Id);

            if (fullIdentity == null) {
                return null;
            }

            context.Identity.Remove(fullIdentity);
            await context.SaveChangesAsync();
            return fullIdentity;
        }
    }
}
