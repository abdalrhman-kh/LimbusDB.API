using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface ISinAffinityRepository
    {
        public Task<SinAffinity> CreateAsync(SinAffinity sinAffinity);

        public Task<List<SinAffinity>> GatAllAsync();

        public Task<SinAffinity?> GetByIdAsync(Guid id);

        public Task<SinAffinity?> UpdateAsync(Guid id , SinAffinity sinAffinity);

        public Task<SinAffinity?> DeleteAsync(SinAffinity sinAffinity); 
    }
}
