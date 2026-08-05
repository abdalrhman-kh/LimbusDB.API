using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Models.DTO.CreateRequests
{
    public class SinAffinityCoutCreateRequestDTO
    {
        public Guid SinAffinityId { get; set; }
        public bool IsOwned { get; set; }
        public int SinCount { get; set; }

        public List<Guid>? PassiveIds { get; set; }
    }
}
