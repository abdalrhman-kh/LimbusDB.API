using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IPassivesRepository
    {
        public Task<Passives> CreateAsync(Passives passives, List<Guid> sinAffinityCountIds, List<Guid> statusEffectIds);

        public Task<List<Passives>> GetAllAsync(); 

        public Task<Passives?> GetByIdAsync(Guid id);

        public Task<Passives?> UpdateAsync(Guid id, Passives passives, List<Guid> sinAffinityCountIds, List<Guid> statusEffectIds);

        public Task<Passives?> DeleteAsync(Passives passives);
    }
}
