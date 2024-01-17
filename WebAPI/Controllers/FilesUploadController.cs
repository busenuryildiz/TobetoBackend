using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Route("UploadProfileImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadProfileImage(IFormFile file, CancellationToken cancellationToken)
        {
            try
            {
                var result = await WriteFile(file, "ProfileImages");
                return Ok(result);
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
