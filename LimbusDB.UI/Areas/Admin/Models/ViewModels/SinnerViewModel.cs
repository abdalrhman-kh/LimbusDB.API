using System.ComponentModel.DataAnnotations;

namespace LimbusDB.UI.Models.ViewModels
{
    public class SinnerViewModel
    {
        [Required]
        public Guid SinnerId { get; set; }
        [Required]
        public int SinnerNumber { get; set; }
        [Required]
        public string SinnerName { get; set; }
        [Required]
        public string? SinnerSymbolImageURL { get; set; }
    }
}
