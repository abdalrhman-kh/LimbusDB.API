namespace LimbusDB.UI.Models.ViewModels
{
    public class StatusEffectViewModel
    {
        public Guid Id { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public decimal StatusType { get; set; }
        public string? StatusImageURL { get; set; }
    }
}
