using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Subject;
using Business.DTOs.Response.Subject;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("add")]
        [ValidateModel(typeof(CreateSubjectRequestValidator))]
        public async Task<ActionResult<CreatedSubjectResponse>> Add([FromBody] CreateSubjectRequest createSubjectRequest)
        {
            var result = await _subjectService.Add(createSubjectRequest);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<DeletedSubjectResponse>> Delete(int id)
        {
            var result = await _subjectService.Delete(new DeleteSubjectRequest { Id = id });
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<UpdatedSubjectResponse>> Update([FromBody] UpdateSubjectRequest updateSubjectRequest)
        {
            var result = await _subjectService.Update(updateSubjectRequest);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<GetByIdSubjectResponse>> GetById(int id)
        {
            var result = await _subjectService.GetById(id);
            return Ok(result);
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<IPaginate<GetListSubjectInfoResponse>>> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _subjectService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}