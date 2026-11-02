namespace LimbusDB.UI.Models.ViewModels
{
    public class TraitKeyWordViewModel
    {
        public Guid Id { get; set; }
        public string TraitName { get; set; }
        public List<Guid>? IdentityIds { get; set; }
    }
}
