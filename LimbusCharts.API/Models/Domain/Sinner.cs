using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class Sinner
    {
        [Required]
        public Guid SinnerId { get; set; }
        [Required]
        public int SinnerNumber { get; set; }
        [Required]
        public string SinnerName { get; set; }
        public string? SinnerSymbolImageURL { get; set;}
    }
}
