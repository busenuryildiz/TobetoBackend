using Business.Abstract;
using Business.DTOs.Request;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {

        ICatalogService _catalogService;
        public CatalogsController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
        [HttpPost("AddCatalog")]
        public async Task<IActionResult> Add([FromBody] CreateCatalogRequest createCatalogRequest)
        {
            var result = await _catalogService.Add(createCatalogRequest);
            return Ok(result);
        }

        [HttpPost("DeleteCatalog")]
        public async Task<IActionResult> Delete([FromBody] DeleteCatalogRequest deleteCatalogRequest)
        {
            var result = await _catalogService.Delete(deleteCatalogRequest);
            return Ok(result);
        }
        [HttpPost("UpdateCatalog")]
        public async Task<IActionResult> Update([FromBody] UpdateCatalogRequest updateCatalogRequest)
        {
            var result = await _catalogService.Update(updateCatalogRequest);
            return Ok(result);
        }

        [HttpGet("GetListCatalog")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _catalogService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
