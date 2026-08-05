using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LimbusCharts.API.Models.Domain
{
    public class TraitKeyword
    {
        public Guid Id { get; set; }
        [Required]
        public string TraitName { get; set; }
        [JsonIgnore]
        public ICollection<Identity>? Identities { get; set; }
    }
}
