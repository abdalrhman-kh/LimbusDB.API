using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Models.DTO.CreateRequests
{
    public class PassivesCreateRequestDTO
    {
        public string PassiveName { get; set; }
        public string PassiveDescription { get; set; }
        public Guid IdentityId { get; set; }


        public List<Guid>? SinAffinityCountIds { get; set; }
        public List<Guid>? statusEffectIds { get; set; }
    }
}
