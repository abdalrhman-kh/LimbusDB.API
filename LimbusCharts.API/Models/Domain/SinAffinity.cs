using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class SinAffinity
    {
        public Guid Id { get; set; }
        [Required]
        public string SinName { get; set; }
        public string? SinImageURL { get; set; }
    }
}
