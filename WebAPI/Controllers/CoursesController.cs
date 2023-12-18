//using Business.Abstract;
//using Core.DataAccess.Paging;
//using Entities.Concrete;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CoursesController : ControllerBase
//    {
//        private ICourseService _courseService;

//        public CoursesController(ICourseService courseService)
//        {
//            _courseService = courseService;
//        }

//        [HttpGet("GetList")]
//        public async Task<IActionResult> GetList()
//        {
//            var result = await _courseService.GetListAsync();
//            return Ok(result);
//        }
//    }
//}
