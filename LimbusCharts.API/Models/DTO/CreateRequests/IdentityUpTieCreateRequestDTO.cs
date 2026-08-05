namespace LimbusCharts.API.Models.DTO.CreateRequests
{
    public class IdentityUpTieCreateRequestDTO
    {
        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public Guid UpTieId { get; set; }

    }
}
