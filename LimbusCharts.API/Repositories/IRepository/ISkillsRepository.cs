using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface ISkillsRepository
    {
        public Task<Skills> CreateAsync(Skills skills, List<Guid> statusEffectIds);

        public Task<List<Skills>> GetAllAsync();

        public Task<Skills?> GetByIdAsync(Guid id);

        public Task<Skills?> UpdateAsync(Guid id, Skills skills, List<Guid> statusEffectIds);

        public Task<Skills?> DeleteAsync(Skills skills);
    }
}
