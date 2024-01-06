using AutoMapper;
using Business.DTOs.Request.Survey;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly IMapper _mapper;

        public SurveysController(ISurveyService surveyService, IMapper mapper)
        {
            _surveyService = surveyService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        [ValidateModel(typeof(CreateSurveyRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateSurveyRequest createSurveyRequest)
        {
            var result = await _surveyService.Add(createSurveyRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSurveyRequest updateSurveyRequest)
        {
            var result = await _surveyService.Update(updateSurveyRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSurveyRequest deleteSurveyRequest)
        {
            var result = await _surveyService.Delete(deleteSurveyRequest);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _surveyService.GetById(id);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _surveyService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}