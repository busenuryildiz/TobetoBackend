using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.DTOs.Request.Survey;
using Business.DTOs.Request.SurveyAnswer;
using Business.DTOs.Request.SurveyQuestion;
using Business.DTOs.Response.SurveyAnswer;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SurveysController : ControllerBase
{
    private readonly ISurveyService _surveyService;
    private readonly ISurveyQuestionService _surveyQuestionService;
    private readonly ISurveyAnswerService _surveyAnswerService;

    public SurveysController(ISurveyService surveyService, ISurveyQuestionService surveyQuestionService, ISurveyAnswerService surveyAnswerService)
    {
        _surveyService = surveyService ?? throw new ArgumentNullException(nameof(surveyService));
        _surveyQuestionService = surveyQuestionService ?? throw new ArgumentNullException(nameof(surveyQuestionService));
        _surveyAnswerService = surveyAnswerService ?? throw new ArgumentNullException(nameof(surveyAnswerService));
    }

    [HttpGet("surveys")]
    public async Task<IActionResult> GetSurveys([FromQuery] PageRequest pageRequest)
    {
        var surveys = await _surveyService.GetListAsync(pageRequest);
        return Ok(surveys);
    }

    [HttpGet("surveys/{id}")]
    public async Task<IActionResult> GetSurveyById(int id)
    {
        var survey = await _surveyService.GetById(id);
        if (survey == null)
            return NotFound();

        return Ok(survey);
    }

    [HttpPost("surveys")]
    public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyRequest createSurveyRequest)
    {
        var createdSurvey = await _surveyService.Add(createSurveyRequest);
        return Ok(createdSurvey);
    }

    [HttpPut("surveys/{id}")]
    public async Task<IActionResult> UpdateSurvey(int id, [FromBody] UpdateSurveyRequest updateSurveyRequest)
    {
        updateSurveyRequest.Id = id;
        var updatedSurvey = await _surveyService.Update(updateSurveyRequest);               
        if (updatedSurvey == null)
            return NotFound();

        return Ok(updatedSurvey);
    }

    [HttpDelete("surveys/{id}")]
    public async Task<IActionResult> DeleteSurvey(int id)
    {
        var deleteSurveyRequest = new DeleteSurveyRequest { Id = id };
        var deletedSurvey = await _surveyService.Delete(deleteSurveyRequest);
        if (deletedSurvey == null)
            return NotFound();

        return Ok(deletedSurvey);
    }

    [HttpGet("surveyquestions")]
    public async Task<IActionResult> GetSurveyQuestions([FromQuery] PageRequest pageRequest)
    {
        var surveyQuestions = await _surveyQuestionService.GetListAsync(pageRequest);
        return Ok(surveyQuestions);
    }

    [HttpGet("surveyquestions/{id}")]
    public async Task<IActionResult> GetSurveyQuestionById(int id)
    {
        var surveyQuestion = await _surveyQuestionService.GetById(id);
        if (surveyQuestion == null)
            return NotFound();

        return Ok(surveyQuestion);
    }

    [HttpPost("surveyquestions")]
    public async Task<IActionResult> CreateSurveyQuestion([FromBody] AddSurveyQuestionRequest addSurveyQuestionRequest)
    {
        var createdSurveyQuestion = await _surveyQuestionService.Add(addSurveyQuestionRequest);
        return Ok(createdSurveyQuestion);
    }

    [HttpPut("surveyquestions/{id}")]
    public async Task<IActionResult> UpdateSurveyQuestion(int id, [FromBody] UpdateSurveyQuestionRequest updateSurveyQuestionRequest)
    {
        updateSurveyQuestionRequest.Id = id;
        var updatedSurveyQuestion = await _surveyQuestionService.Update(updateSurveyQuestionRequest);
        if (updatedSurveyQuestion == null)
            return NotFound();

        return Ok(updatedSurveyQuestion);
    }

    [HttpDelete("surveyquestions/{id}")]
    public async Task<IActionResult> DeleteSurveyQuestion(int id)
    {
        var deleteSurveyQuestionRequest = new DeleteSurveyQuestionRequest { Id = id };
        var deletedSurveyQuestion = await _surveyQuestionService.Delete(deleteSurveyQuestionRequest);
        if (deletedSurveyQuestion == null)
            return NotFound();

        return Ok(deletedSurveyQuestion);
    }

    [HttpGet("surveyanswers")]
    public async Task<IActionResult> GetSurveyAnswers([FromQuery] PageRequest pageRequest)
    {
        var surveyAnswers = await _surveyAnswerService.GetListAsync(pageRequest);
        return Ok(surveyAnswers);
    }

    [HttpGet("surveyanswers/{id}")]
    public async Task<IActionResult> GetSurveyAnswerById(int id)
    {
        var surveyAnswer = await _surveyAnswerService.GetById(id);
        if (surveyAnswer == null)
            return NotFound();

        return Ok(surveyAnswer);
    }

    [HttpPost("surveyanswers")]
    public async Task<IActionResult> CreateSurveyAnswer([FromBody] AddSurveyAnswerRequest addSurveyAnswerRequest)
    {
        var createdSurveyAnswer = await _surveyAnswerService.Add(addSurveyAnswerRequest);
        return Ok(createdSurveyAnswer);
    }

    [HttpPut("surveyanswers/{id}")]
    public async Task<IActionResult> UpdateSurveyAnswer(int id, [FromBody] UpdateSurveyAnswerRequest updateSurveyAnswerRequest)
    {
        updateSurveyAnswerRequest.Id = id;
        var updatedSurveyAnswer = await _surveyAnswerService.Update(updateSurveyAnswerRequest);
        if (updatedSurveyAnswer == null)
            return NotFound();

        return Ok(updatedSurveyAnswer);
    }

    [HttpDelete("surveyanswers/{id}")]
    public async Task<IActionResult> DeleteSurveyAnswer(int id)
    {
        var deleteSurveyAnswerRequest = new DeleteSurveyAnswerRequest { Id = id };
        var deletedSurveyAnswer = await _surveyAnswerService.Delete(deleteSurveyAnswerRequest);
        if (deletedSurveyAnswer == null)
            return NotFound();

        return Ok(deletedSurveyAnswer);
    }
    [HttpGet("user/{userId}/survey/{surveyId}")]
    public async Task<ActionResult<ICollection<GetSurveyAnswerResponse>>> GetUserSurveyAnswers(Guid userId, int surveyId)
    {
        try
        {
            var surveyAnswers = await _surveyAnswerService.GetUserSurveyAnswers(userId, surveyId);
            return Ok(surveyAnswers);
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("GetUnsentSurveys/{userId}")] // İsteği ele alacak route'u belirtin
    public async Task<IActionResult> GetUnsentSurveys(Guid userId)
    {
        try
        {
            var unsentSurveys = await _surveyService.GetUnsentSurveysAsync(userId);

            // Burada unsentSurveys listesini kullanabilirsiniz.

            return Ok(unsentSurveys); // İstenirse listeyi JSON olarak döndürür.
        }
        catch (Exception ex)
        {
            // Hata durumunda uygun bir şekilde işleyin.
            return StatusCode(500, "Internal Server Error");
        }
    }


    [HttpPost("SubmitAnswers")]
    public async Task<IActionResult> SubmitAnswers([FromBody] List<AddSurveyAnswerRequest> addSurveyAnswerRequests)
    {
        // TODO: Validations and error handling

        var createdSurveyAnswers = await _surveyAnswerService.SubmitAnswers(addSurveyAnswerRequests);

        // TODO: Additional logic after submitting answers

        return Ok(createdSurveyAnswers);
    }

    [HttpGet("surveyansweraverages")]
    public async Task<IActionResult> GetSurveyAnswerAverages()
    {
        try
        {
            var questionAverages = await _surveyAnswerService.CalculateQuestionAverages();
            return Ok(questionAverages);
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

}
