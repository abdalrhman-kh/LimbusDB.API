using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class SinAffinityCount
    {
        public Guid Id { get; set; }
        [Required]
        public Guid SinAffinityId { get; set; }
        [Required]
        public bool IsOwned { get; set; }
        [Required]
        public int SinCount { get; set; }

        [Required]

        public SinAffinity sinAffinity { get; set; }
        public ICollection<Passives>? Passives { get; set; }
    }
}
