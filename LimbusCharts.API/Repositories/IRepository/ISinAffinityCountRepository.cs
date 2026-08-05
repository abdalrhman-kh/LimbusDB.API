using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface ISinAffinityCountRepository
    {
        public Task<SinAffinityCount> CreateAsync(SinAffinityCount sinAffinityCount);

        public Task<List<SinAffinityCount>> GetAllAsync();

        public Task<SinAffinityCount?> GetByIdAsync(Guid id);

        public Task<SinAffinityCount?> UpdateAsync(Guid id, SinAffinityCount sinAffinityCount);
        public Task<SinAffinityCount?> DeleteAsync(SinAffinityCount sinAffinityCount);
    }
}
