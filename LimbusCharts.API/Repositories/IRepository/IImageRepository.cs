using LimbusCharts.API.Models.Domain;

namespace LimbusCharts.API.Repositories.IRepository
{
    public interface IImageRepository
    {
        public Task<Image> UploadAsync(Image image);
    }
}
