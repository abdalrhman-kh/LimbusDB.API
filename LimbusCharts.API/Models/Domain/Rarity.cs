using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class Rarity
    {
        [Required]
        public Guid RarityId { get; set; }
        [Required]
        public int RarityType { get; set; }
        [Required]
        public string? RarityImageURL { get; set; }
    }
}
