using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IStatusEffectRepository
    {
        public Task<List<StatusEffect>> GetAllAsync(string? StatusNameFillter = null, bool IsAscending = true);
        public Task<StatusEffect?> GetByIdAsync(Guid id);
        public Task<StatusEffect?> CreateAsync(StatusEffect statusEffect);
        public Task<StatusEffect?> UpdateAsync(Guid id , StatusEffect statusEffect);
        public Task<StatusEffect?> DeleteAsync(StatusEffect statusEffect);
    }
}
