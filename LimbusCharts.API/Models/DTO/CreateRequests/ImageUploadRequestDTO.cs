using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.DTO.CreateRequests
{
    public class ImageUploadRequestDTO
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }
    }
}
