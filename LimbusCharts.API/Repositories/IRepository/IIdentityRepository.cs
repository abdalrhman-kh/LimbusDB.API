using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IIdentityRepository
    {
        public Task<List<Identity>> GetAllAsync(string? name, int? season, string? sinner, int? rarity, int? minSpeed,
             int? maxSpeed, string? statusEffect, string? traitKeyword, int? maxHealth, int? defenseLevel,
             double? slashResistance, double? bluntResistance, double? piercesResistance,
             bool isAscending = false, int pageNumber = 1, int pageSize = 15);
        public Task<Identity?> GetByIdAsync(Guid id);
        public Task<Identity> CreateAsync(Identity identity, List<Guid> statusEffectIds, List<Guid> traitKeywordIds, List<Guid> staggerThresholdIds, List<Guid> IdentityUpTieIds);
        public Task<Identity?> UpdateAsync(Guid id, Identity identity, List<Guid> statusEffectIds, List<Guid> traitKeywordIds, List<Guid> staggerThresholdIds, List<Guid> IdentityUpTieIds);
        public  Task<Identity?> DeleteAsync(Identity identity);
    }
}
