using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface ITraitKeywordRepository
    {
        public Task<TraitKeyword> CreateAsync(TraitKeyword traitKeyword);

        public Task<List<TraitKeyword>> GetAllAsync(string? traitName, bool isAscending = true);

        public Task<TraitKeyword?> GetByIdAsync(Guid id);

        public Task<TraitKeyword?> UpdateAsync(Guid id, TraitKeyword traitKeyword);

        public Task<TraitKeyword?> DeleteAsync(TraitKeyword traitKeyword);
    }
}
