namespace LimbusCharts.API.Models.DTO
{
    public class SeasonDTO
    {
        public Guid SeasonId { get; set; }

        public string SeasonName { get; set; }

        public int SeasonNumber { get; set; }

        public string? SeasonImageURL { get; set; }
    }
}
