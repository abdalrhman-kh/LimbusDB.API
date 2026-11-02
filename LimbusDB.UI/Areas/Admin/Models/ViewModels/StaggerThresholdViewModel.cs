namespace LimbusDB.UI.Models.ViewModels
{
    public class StaggerThresholdViewModel
    {
        public Guid Id { get; set; }
        public double Percentage { get; set; }
        public List<Guid>? identityIds { get; set; }
    }
}
