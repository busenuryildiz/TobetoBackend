using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccess.Context;
using Entities.Concretes.Profiles;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesUploadController : ControllerBase
    {
        private readonly TobetoContext _context;
        private Cloudinary _cloudinary;

        public FilesUploadController(TobetoContext context, IConfiguration configuration)
        {
            _context = context;
            Account account = new Account(
                "duyrywg64",
                 "167425327462643",
             "5tBlGAF7aivpDfETYuo32pwhmuA");

            _cloudinary = new Cloudinary(account);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("ProfileImage")]
        public IActionResult UploadProfileImage(Guid userId, IFormFile formFile)
        {
            // Yüklenen dosyanın adını değiştir
            string uploadedFileName = $"{userId}_profileImage";

            // Cloudinary'ye dosyayı yükle
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(uploadedFileName, formFile.OpenReadStream()),
                PublicId = uploadedFileName,
                Folder = "Profile Images", // Klasör adını belirtin
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            // Cloudinary'den dönen güvenli URL'yi kullanarak kullanıcı profili güncelle
            string imageUrl = uploadResult.SecureUri.AbsoluteUri;

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.ImagePath = imageUrl;
                _context.SaveChanges();
                return Ok(imageUrl); // Başarılı yanıt döndür
            }
            else
            {
                return NotFound(); // Kullanıcı bulunamadı, 404 hatası döndür
            }
        }
      



        [HttpPost, DisableRequestSizeLimit]
        [Route("Certificate")]
        public IActionResult UploadCertificate(Guid studentId, int courseId, IFormFile formFile)
        {
            string uploadedFileName = $"{studentId}_{courseId}_certificate";

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(uploadedFileName, formFile.OpenReadStream()),
                PublicId = uploadedFileName,
                Folder = "Certificates", // Klasör adını belirtin
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            string imageUrl = uploadResult.SecureUri.AbsoluteUri;

            var studentCourse = _context.StudentCourses.FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if (studentCourse != null)
            {
                studentCourse.CertificatePath = imageUrl;
                _context.SaveChanges();
                return Ok(imageUrl); // Başarılı yanıt döndür
            }
            else
            {
                return NotFound(); // Öğrenci kurs ilişkisi bulunamadı, 404 hatası döndür
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UserCertificate")]
        public IActionResult UploadUserCertificate(Guid userId, IFormFile formFile)
        {
            try
            {
                // Dosya adını belirleme
                string originalFileName = Path.GetFileNameWithoutExtension(formFile.FileName); // Uzantısız dosya adı
                string uploadedFileName = $"{userId}_certificate_{originalFileName}";

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(uploadedFileName, formFile.OpenReadStream()),
                    PublicId = uploadedFileName,
                    Folder = "UserCertificates", // Klasör adını belirtin
                };

                var uploadResult = _cloudinary.Upload(uploadParams);

                string imageUrl = uploadResult.SecureUri.AbsoluteUri;

                // Kullanıcının sertifikasını al
                var userCertificate = _context.Certificates.FirstOrDefault(c => c.UserId == userId);

                if (userCertificate != null)
                {
                    // Dosya isminin farklı olup olmadığını kontrol et
                    if (userCertificate.ImagePath != imageUrl)
                    {
                        // Farklıysa, resim yolunu güncelle
                        userCertificate.ImagePath = imageUrl;
                        userCertificate.Name = originalFileName; // Certificate tablosundaki Name alanını güncelle
                        _context.SaveChanges();
                    }

                    return Ok(imageUrl); // Başarılı yanıt döndür
                }
                else
                {
                    // Eğer kullanıcının sertifikası yoksa, yeni bir sertifika oluşturabilirsiniz
                    var newCertificate = new Certificate
                    {
                        UserId = userId,
                        ImagePath = imageUrl,
                        Name = originalFileName // Yeni sertifika oluşturulduğunda Name'i belirle
                                                // Diğer özellikleri de isteğe bağlı olarak ayarlayabilirsiniz
                    };

                    _context.Certificates.Add(newCertificate);
                    _context.SaveChanges();

                    return Ok(imageUrl);
                }
            }
            catch (Exception ex)
            {
                // Hataları yönet
                while (ex != null)
                {
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                    ex = ex.InnerException;
                }

                return StatusCode(500, "Internal Server Error");
            }
        }




        [HttpPost, DisableRequestSizeLimit]
        [Route("CourseImage")]
        public IActionResult UploadCourseImage(int courseId, IFormFile formFile)
        {
            string uploadedFileName = $"{courseId}_courseImage";

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(uploadedFileName, formFile.OpenReadStream()),
                PublicId = uploadedFileName,
                Folder = "Course Images", // Klasör adını belirtin
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            string imageUrl = uploadResult.SecureUri.AbsoluteUri;

            var course = _context.Courses.FirstOrDefault(u => u.Id == courseId);
            if (course != null)
            {
                course.ImagePath = imageUrl;
                _context.SaveChanges();
                return Ok(imageUrl); 
            }
            else
            {
                return NotFound(); 
            }
        }

    }
}