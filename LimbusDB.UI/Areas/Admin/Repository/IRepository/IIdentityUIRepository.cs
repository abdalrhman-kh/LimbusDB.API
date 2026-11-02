using LimbusDB.UI.Models.DTO;
using LimbusDB.UI.Models.ViewModels;

namespace LimbusDB.UI.Areas.Admin.Repository.IRepository
{
    public interface IIdentityUIRepository
    {
        public Task<IEnumerable<SinnerViewModel>> GetSinnersAsync();
        public Task<IEnumerable<RarityViewModel>> GetRarityAsync();
        public Task<IEnumerable<SeasonViewModel>> GetSeasonAsync();
        public Task<IEnumerable<StaggerThresholdViewModel>> GetStaggerAsync();
        public Task<IEnumerable<StatusEffectViewModel>> GetStatusEffectsAsync();
        public Task<IEnumerable<TraitKeyWordViewModel>> GetTraitKeywordsAsync();
        public Task<IEnumerable<IdentityViewModel>> GetIdentitiesAsync();
    }
}
