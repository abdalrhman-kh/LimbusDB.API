using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;

namespace LimbusCharts.API.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor http;
        private readonly DataDbContext context;

        public ImageRepository(IWebHostEnvironment env, IHttpContextAccessor http, DataDbContext context)
        {
            this.env = env;
            this.http = http;
            this.context = context;
        }
        public async Task<Image> UploadAsync(Image image)
        {
            var localPath = Path.Combine(env.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

            using var stream = new FileStream(localPath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlPath = $"{http.HttpContext.Request.Scheme}://{http.HttpContext.Request.Host}{http.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlPath;
            await context.Image.AddAsync(image);
            await context.SaveChangesAsync();
            return image;
        }
    }
}
