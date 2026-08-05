namespace LimbusCharts.API.Models.DTO.CreateRequests
{
    public class IdentityCreateRequestDTO
    {
        public string IdentityName { get; set; }
        public int MaxHealth { get; set; }
        public int DefenseLevel { get; set; }
        public double SlashResistance { get; set; }
        public double BluntResistance { get; set; }
        public double PierceResistance { get; set; }
        public string? UpTieImage_1 { get; set; }
        public string? UpTieImage_2 { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public Guid SinnerId { get; set; }
        public Guid RarityId { get; set; }
        public Guid SeasonId { get; set; }

        public List<Guid> StatusEffectIds { get; set; }
        public List<Guid>? IdentityUpTieIds { get; set; }
        public List<Guid> TraitKeyWordIds { get; set; }
        public List<Guid> StaggerThresholdIds { get; set; }
    }
}
