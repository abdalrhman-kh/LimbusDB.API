namespace LimbusCharts.API.Models.DTO.CreateRequests
{
    public class StatusEffectCreateRequestDTO
    {
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public int StatusType { get; set; }
        public string? StatusImageURL { get; set; }

    }
}
