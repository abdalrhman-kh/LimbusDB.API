using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly DataDbContext context;

        public SkillsRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<Skills> CreateAsync(Skills skills, List<Guid> statusEffectIds)
        {
            var statusEffects = await context.StatusEffect.Where(x => statusEffectIds.Contains(x.Id)).ToListAsync();
            var UpTie = await context.UpTie.FirstOrDefaultAsync(x => x.UpTieId == skills.UpTieId);
            var sinAffinity = await context.SinAffinity.FirstOrDefaultAsync(x => x.Id == skills.SinAffinityId);

            skills.StatusEffects = statusEffects;
            skills.UpTie = UpTie;
            skills.SinAffinity = sinAffinity;

            await context.Skills.AddAsync(skills);
            await context.SaveChangesAsync();
            return skills;
        }

        public async Task<Skills?> DeleteAsync(Skills skills)
        {
            context.Skills.Remove(skills);
            await context.SaveChangesAsync();
            return skills;
        }

        public async Task<List<Skills>> GetAllAsync()
        {
            return await context.Skills.Include(x => x.StatusEffects).Include(x => x.UpTie).Include(x => x.SinAffinity).ToListAsync();
        }

        public async Task<Skills?> GetByIdAsync(Guid id)
        {
            return await context.Skills.Include(x => x.StatusEffects).Include(x => x.UpTie).Include(x => x.SinAffinity).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Skills?> UpdateAsync(Guid id, Skills skills, List<Guid> statusEffectIds)
        {
            var oldSkill = await GetByIdAsync(id);

            if (oldSkill == null)
                return null;

            var statusEffects = await context.StatusEffect.Where(x => statusEffectIds.Contains(x.Id)).ToListAsync();
            var UpTie = await context.UpTie.FirstOrDefaultAsync(x => x.UpTieId == skills.UpTieId);
            var sinAffinity = await context.SinAffinity.FirstOrDefaultAsync(x => x.Id == skills.SinAffinityId);

            if(oldSkill.StatusEffects != null && statusEffectIds != null)
            {
                oldSkill.StatusEffects.Clear();
            }

            if(statusEffectIds != null)
            {
                foreach (var statusEffect in statusEffects)
                    oldSkill.StatusEffects.Add(statusEffect);
            }

            oldSkill.SkillType = skills.SkillType;
            oldSkill.SkillName = skills.SkillName;
            oldSkill.SkillDescription = skills.SkillDescription;
            oldSkill.SkillImageURL = skills.SkillImageURL;
            oldSkill.AttackType = skills.AttackType;
            oldSkill.BasePower = skills.BasePower;
            oldSkill.NumberOfCoins  = skills.NumberOfCoins;
            oldSkill.AttackWeight = skills.AttackWeight;
            oldSkill.OffenseLevel = skills.OffenseLevel;
            oldSkill.CoinPower = skills.CoinPower;

            oldSkill.UpTieId = skills.UpTieId;
            oldSkill.SinAffinityId = skills.SinAffinityId;
            oldSkill.UpTie = UpTie;
            oldSkill.SinAffinity = sinAffinity;

            await context.SaveChangesAsync();
            return oldSkill;
        }
    }
}
