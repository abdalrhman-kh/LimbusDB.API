using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Models.DTO
{
    public class SinAffinityCountDTO
    {
        public Guid Id { get; set; }
        public Guid SinAffinityId { get; set; }
        public bool IsOwned { get; set; }
        public int SinCount { get; set; }

        public SinAffinity sinAffinity { get; set; }
        public List<Guid>? PassiveIds { get; set; }
    }
}
