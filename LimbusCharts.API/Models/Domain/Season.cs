using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class Season
    {
        [Required]
        public Guid SeasonId { get; set; }
        [Required]
        public string SeasonName { get; set; }
        [Required]
        public int SeasonNumber { get; set; }
        [Required]
        public string? SeasonImageURL { get; set; }
    }
}
