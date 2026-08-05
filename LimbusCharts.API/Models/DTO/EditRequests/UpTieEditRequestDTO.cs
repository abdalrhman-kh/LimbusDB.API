using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.DTO.EditRequests
{
    public class UpTieEditRequestDTO
    {
        public int UpTieType { get; set; }
        public string? UpTieImageURL { get; set; }
    }
}
