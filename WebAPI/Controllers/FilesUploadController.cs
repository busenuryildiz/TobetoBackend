using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [ApiController]
    public class FilesUploadController : ControllerBase
    {
        
        private async Task<string> WriteFile(IFormFile file, string subfolder)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", subfolder);

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var filePath = Path.Combine(uploadPath, filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return filename;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, return an error, etc.)
                return filename;
            }
        }


        private readonly Cloudinary _cloudinary;

        public FilesUploadController()
        {
            Account account = new Account(
                "duyrywg64",
                "167425327462643",
                "5tBlGAF7aivpDfETYuo32pwhmuA"
            );

            _cloudinary = new Cloudinary(account);
        }


        [HttpPost]
        [Route("UploadProfileImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadProfileImage(IFormFile file, CancellationToken cancellationToken)
        {
            try
            {
                // Dosya adını kullanıcı adı ile birleştirerek Cloudinary'e yükle
                var username = "example_user"; // Kullanıcı adını burada alabilirsiniz
                var fileName = $"{username}_profileimage";
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileName, file.OpenReadStream()),
                    Folder = "ProfileImages" // Cloudinary'de dosyanın yükleneceği klasör adı
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                // Cloudinary'den dönen URL'yi veritabanına kaydetme işlemi burada gerçekleştirilir...

                return Ok(uploadResult.SecureUrl.AbsoluteUri);
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
                return BadRequest("Error uploading profile image");
            }
        }


        [HttpPost]
        [Route("UploadCertificate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadCertificate(IFormFile file, CancellationToken cancellationToken)
        {
            try
            {
                var result = await WriteFile(file, "Certificates");
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("UploadCourseImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadCourseImage(IFormFile file, CancellationToken cancellationToken)
        {
            try
            {
                var result = await WriteFile(file, "CoursesImages");
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
