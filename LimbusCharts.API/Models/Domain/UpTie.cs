using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class UpTie
    {
        [Required]
        public Guid UpTieId { get; set; }
        [Required]
        public int UpTieType { get; set; }
        public string? UpTieImageURL  { get; set; }
    }
}
