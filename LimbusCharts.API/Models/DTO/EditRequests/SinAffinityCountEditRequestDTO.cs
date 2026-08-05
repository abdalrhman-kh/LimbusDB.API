namespace LimbusCharts.API.Models.DTO.EditRequests
{
    public class SinAffinityCountEditRequestDTO
    {
        public Guid SinAffinityId { get; set; }
        public bool IsOwned { get; set; }
        public int SinCount { get; set; }

        public List<Guid>? PassiveIds { get; set; }
    }
}
