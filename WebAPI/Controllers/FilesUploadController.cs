using Entities.Concretes.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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



        // Cloudinary ayarlarınızı tanımlayın
        private readonly Cloudinary _cloudinary;

        public ProfileController()
        {
            // Cloudinary ayarlarınızı burada tanımlayın
            Account account = new Account(
                "cloud_name",
                "api_key",
                "api_secret"
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
            // Kullanıcı adı ve dosya adını birleştirerek Cloudinary'e yükle
            var fileName = $"{userId}_profileimage";
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, file.OpenReadStream()),
                Folder = "ProfileImages" // Cloudinary'de dosyanın yükleneceği klasör adı
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            // Cloudinary'den dönen URL'yi veritabanına kaydetme işlemi burada gerçekleştirilir...

            return Ok(uploadResult.SecureUrl.AbsoluteUri);
        }
        catch (Exception ex)
        {
            // Handle the exception (log, return an error, etc.)
            throw ex;
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
