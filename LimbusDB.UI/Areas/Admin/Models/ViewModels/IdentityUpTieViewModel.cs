namespace LimbusDB.UI.Models.ViewModels
{
    public class IdentityUpTieViewModel
    {
        public Guid IdentityUpTieId { get; set; }
        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public Guid UpTieId { get; set; }

        public List<Guid>? IdentityIds { get; set; }
    }
}
