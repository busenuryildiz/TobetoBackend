using Business.Abstracts;
using Business.DTOs.Request.Category;
using Business.DTOs.Request.Category;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        [ValidateModel(typeof(CreateCategoryRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateCategoryRequest createCategoryRequest)
        {
            var result = await _categoryService.Add(createCategoryRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryRequest deleteCategoryRequest)
        {
            var result = await _categoryService.Delete(deleteCategoryRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            var result = await _categoryService.Update(updateCategoryRequest);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _categoryService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
