using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Exam;
using Business.DTOs.Response.Exam;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Rules;
using Business.DTOs.Response.Exam;
using Business.DTOs.Response.Question;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ExamManager : IExamService
    {
        private readonly IExamDal _examDal;
        private readonly IMapper _mapper;
        ExamBusinessRules _examBusinessRules;

        public ExamManager(IExamDal examDal, IMapper mapper, ExamBusinessRules examBusinessRules)
        {
            _examDal = examDal;
            _mapper = mapper;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _examDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListExamResponse>>(data);
            return result;
        }

        public async Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest)
        {
            await _examBusinessRules.ValidateExamPoint(createExamRequest.Point);
            var examDal = _mapper.Map<Exam>(createExamRequest);
            var createdExam = await _examDal.AddAsync(examDal);
            var result = _mapper.Map<CreatedExamResponse>(createdExam);
            return result;
        }

        public async Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest)
        {
            var examDal = await _examDal.GetAsync(e => e.Id == updateExamRequest.Id);
            _mapper.Map(updateExamRequest, examDal);
            await _examDal.UpdateAsync(examDal);
            var result = _mapper.Map<UpdatedExamResponse>(examDal);
            return result;
        }

        public async Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest)
        {
            var examDal = await _examDal.GetAsync(e => e.Id == deleteExamRequest.Id);
            var deletedExam = await _examDal.DeleteAsync(examDal);
            var result = _mapper.Map<DeletedExamResponse>(deletedExam);
            return result;
        }

        public async Task<CreatedExamResponse> GetById(int id)
        {
            var result = await _examDal.GetAsync(c => c.Id == id);
            Exam mappedExam = _mapper.Map<Exam>(result);
            CreatedExamResponse createdExamResponse = _mapper.Map<CreatedExamResponse>(mappedExam);
            return createdExamResponse;
        }


        public async Task<List<GetListExamResponse>> GetExamsByCourseId(int courseId)
        {
            var examDals = await _examDal.GetListAsync(e => e.CourseId == courseId);
            var result = _mapper.Map<List<GetListExamResponse>>(examDals);
            return result;
        }

        public async Task<List<GetListQuestionResponse>> GetRandomQuestionsByExamId(int examId)
        {
            var result = await _examBusinessRules.GetRandomQuestionsByExamId(examId);
            return result;
        }
    }
}
