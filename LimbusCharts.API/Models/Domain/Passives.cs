using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class Passives
    {
        public Guid Id { get; set; }
        [Required]
        public string PassiveName { get; set; }
        [Required]
        public int PassiveType { get; set; }
        [Required]
        public string PassiveDescription { get; set; }
        [Required]
        public Guid IdentityId { get; set; }

        public Identity identity { get; set; }


        public ICollection<SinAffinityCount>? SinAffinityCounts { get; set; }
        public ICollection<StatusEffect>? statusEffects { get; set; }
    }
}
