using System.ComponentModel.DataAnnotations;
using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Models.DTO
{
    public class IdentityUpTieDTO
    {
        public Guid IdentityUpTieId { get; set; }
        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public UpTieDTO UpTie { get; set; }

        //public List<Guid>? IdentityIds { get; set; }
    }
}
