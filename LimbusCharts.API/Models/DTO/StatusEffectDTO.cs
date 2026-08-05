namespace LimbusCharts.API.Models.DTO
{
    public class StatusEffectDTO
    {
        public Guid Id { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public int StatusType { get; set; }
        public string? StatusImageURL { get; set; }
    }
}
