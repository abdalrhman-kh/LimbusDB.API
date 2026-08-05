using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IStaggerThresholdRepository
    {
        public Task<StaggerThreshold> CreateAsync(StaggerThreshold staggerThreshold);

        public Task<List<StaggerThreshold>> GallAllAsync();

        public Task<StaggerThreshold?> GetByIdAsync(Guid id);

        public Task<StaggerThreshold?> UpdateAsync(Guid id, StaggerThreshold staggerThreshold);

        public Task<StaggerThreshold?> DeleteAsync(StaggerThreshold staggerThreshold);
    }
}
