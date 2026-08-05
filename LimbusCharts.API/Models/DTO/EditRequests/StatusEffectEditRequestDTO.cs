namespace LimbusCharts.API.Models.DTO.EditRequests
{
    public class StatusEffectEditRequestDTO
    {
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public int StatusType { get; set; }
        public string? StatusImageURL { get; set; }
    }
}
