using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LimbusCharts.API.Models.Domain
{
    public class StatusEffect
    {
        public Guid Id { get; set; }
        [Required]
        public string StatusName { get; set; }
        [Required]
        public string StatusDescription { get; set; }
        public int StatusType { get; set; }
        public string? StatusImageURL { get; set; }

        [JsonIgnore]
        public ICollection <Identity>? Identities { get; set; }
        [JsonIgnore]
        public ICollection<Passives>? Passives { get; set; }
        [JsonIgnore]
        public ICollection<Skills>? Skills { get; set; }
    }
}
