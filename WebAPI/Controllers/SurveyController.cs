using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService ?? throw new ArgumentNullException(nameof(surveyService));
        }

        [HttpGet]
        public async Task<IActionResult> GetSurveys()
        {
            try
            {
                var surveys = await _surveyService.GetSurveysAsync();
                return Ok(surveys);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyById(int id)
        {
            try
            {
                var survey = await _surveyService.GetSurveyByIdAsync(id);
                if (survey == null)
                {
                    return NotFound(); // 404 Not Found
                }

                return Ok(survey);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyRequest request)
        {
            try
            {
                var createdSurvey = await _surveyService.CreateSurveyAsync(request);
                return CreatedAtAction(nameof(GetSurveyById), new { id = createdSurvey.Id }, createdSurvey);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(Guid id, [FromBody] UpdateSurveyRequest request)
        {
            try
            {
                var updatedSurvey = await _surveyService.UpdateSurveyAsync(request);
                if (updatedSurvey == null)
                {
                    return NotFound(); // 404 Not Found
                }

                return Ok(updatedSurvey);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            try
            {
                await _surveyService.DeleteSurveyAsync(new DeleteSurveyRequest { Id = id });
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}