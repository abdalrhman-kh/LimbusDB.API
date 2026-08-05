namespace LimbusCharts.API.Models.DTO.EditRequests
{
    public class SkillsEditRequestDTO
    {
        public string SkillType { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public string SkillImageURL { get; set; }
        public string AttackType { get; set; }
        public int UpTie { get; set; }
        public int NumberOfCoins { get; set; }
        public int BasePower { get; set; }
        public int CoinPower { get; set; }
        public int AttackWeight { get; set; }
        public int OffenseLevel { get; set; }
        public Guid UpTieId { get; set; }
        public Guid SinAffinityId { get; set; }


        public List<Guid> StatusEffectIds { get; set; }
    }
}
