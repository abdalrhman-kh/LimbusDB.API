using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LimbusCharts.API.Models.Domain
{
    public class StaggerThreshold
    {
        public Guid Id { get; set; }
        [Required]
        [Range(0.01, 0.99, ErrorMessage = "Out of range")]
        public double Percentage { get; set; }

        [JsonIgnore]
        public ICollection<Identity>? identities { get; set; }
    }
}
