using System.ComponentModel.DataAnnotations;

namespace LimbusCharts.API.Models.Domain
{
    public class Identity
    {
        public Guid Id { get; set; }
        [Required]
        public string IdentityName { get; set; }
        [Required]
        public int MaxHealth { get; set; }
        [Required]
        public int DefenseLevel { get; set; }
        [Required]
        public double SlashResistance { get; set; }
        [Required]
        public double BluntResistance { get; set; }
        [Required]
        public double PierceResistance { get; set; }
        public string? UpTieImage_1 { get; set; }
        public string? UpTieImage_2 { get; set; }
        [Required]
        public DateOnly ReleaseDate { get; set; }

        public Guid SinnerId {  get; set; }
        public Guid RarityId { get; set; }
        public Guid SeasonId { get; set; }


        public Sinner Sinner { get; set; }
        public Rarity Rarity { get; set; }
        public Season Season { get; set; }

        public ICollection<StatusEffect> StatusEffects { get; set; }
        public ICollection<IdentityUpTie>? IdentityUpTies { get; set; }
        public ICollection<TraitKeyword> TraitKeywords { get; set; }
        public ICollection<StaggerThreshold> StaggerThresholds { get; set; }

    }
}
