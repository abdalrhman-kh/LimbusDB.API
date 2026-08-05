using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Models.DTO
{
    public class TraitKeywordDTO
    {
        public Guid Id { get; set; }
        public string TraitName { get; set; }
        public List<Guid>? IdentityIds { get; set; }
    }
}
