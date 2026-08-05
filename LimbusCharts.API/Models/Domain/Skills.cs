using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class Skills
    {
        public Guid Id {  get; set; }
        [Required]
        public string SkillType { get; set; }
        [Required]
        public string SkillName { get; set; }
        [Required]
        public string SkillDescription { get; set; }
        [Required]
        public string SkillImageURL { get; set; }
        [Required]
        public string AttackType { get; set; }
        [Required]
        public int NumberOfCoins { get; set; }
        [Required]
        public int BasePower { get; set; }
        [Required]
        public int CoinPower { get; set; }
        [Required]
        public int AttackWeight { get; set; }
        [Required]
        public int OffenseLevel { get; set; }
        public Guid UpTieId { get; set; }
        public Guid SinAffinityId { get; set; } 

        public SinAffinity SinAffinity { get; set; }
        public UpTie UpTie { get; set; }

        [Required]
        public ICollection<StatusEffect> StatusEffects { get; set; }
    }
}
