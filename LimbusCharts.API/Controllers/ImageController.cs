using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Models.DTO.CreateRequests;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimbusCharts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO request)
        {
            ValidateImage(request);

            if (ModelState.IsValid)
            {
                var imageDomain = new Image
                {
                    File = request.File,
                    FileDescription = request.FileDescription,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileName = request.FileName,
                    FileSize = request.File.Length,
                };

                imageDomain = await imageRepository.UploadAsync(imageDomain);

                return Ok(imageDomain);
            }

            return BadRequest(ModelState);
        }

        private void ValidateImage(ImageUploadRequestDTO request)
        {
            var validExtenstions = new string[] { ".jpg", ".jpeg", ".png", ".webp" };

            if (!validExtenstions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("File", "Invalid Extenstion");
            }

            if(request.File.Length > 10485760)
            {
                ModelState.AddModelError("File", "File size is larger than 10MB");
            }
        }
    }
}
