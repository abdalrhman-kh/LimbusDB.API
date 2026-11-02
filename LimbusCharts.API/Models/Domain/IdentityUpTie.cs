using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class IdentityUpTie
    {
        [Required]
        public Guid IdentityUpTieId { get; set; }
        [Required]
        public int MinSpeed { get; set; }
        [Required]
        public int MaxSpeed { get; set; }

        public Guid UpTieId { get; set; }
        //public Guid? IdentityId { get; set; }

        public UpTie UpTie { get; set; }
        //public Identity? Identity { get; set; }
    }
}
