using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Models.DTO
{
    public class StaggerThresholdDTO
    {
        public Guid Id { get; set; }
        public double Percentage { get; set; }
        public List<Guid>? identityIds { get; set; }
    }
}
