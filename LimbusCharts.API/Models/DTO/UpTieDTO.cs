using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.DTO
{
    public class UpTieDTO
    {
        public Guid UpTieId { get; set; }
        public int UpTieType { get; set; }
        public string? UpTieImageURL { get; set; }
    }
}
