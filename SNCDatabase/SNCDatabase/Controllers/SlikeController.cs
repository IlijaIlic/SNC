using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNCDatabase.Models;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SNCDatabase.Controllers
{
    [ApiController]
    [Route("slike")]
    public class SlikeController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SlikeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("restorani/{id}")]
        public async Task<IActionResult> AddSlikaRestoran([FromForm] IFormFile img, int id)
        {
            try
            {
                if (img == null)
                {
                    return BadRequest("No file uploaded");
                }

                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

                if(!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(img.FileName).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    return BadRequest("Invalid file type.");
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await img.CopyToAsync(fileStream);
                }

                var fileUrl = $"/uploads/{uniqueFileName}";

                var slika = new SlikeRestoran
                {
                    RestoranID = id,
                    SLIKE = fileUrl
                };

                return Ok(new { filePath, fileUrl });


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
}
