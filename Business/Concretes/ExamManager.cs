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

namespace Business.Concretes
{
    public class ExamManager : IExamService
    {
        private readonly IExamDal _repository;
        private readonly IMapper _mapper;

        public ExamManager(IExamDal repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _repository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListExamResponse>>(data);
            return result;
        }

        public async Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest)
        {
            var exam = _mapper.Map<Exam>(createExamRequest);
            var createdExam = await _repository.AddAsync(exam);
            var result = _mapper.Map<CreatedExamResponse>(createdExam);
            return result;
        }

        public async Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest)
        {
            var exam = await _repository.GetAsync(e => e.Id == updateExamRequest.Id);
            _mapper.Map(updateExamRequest, exam);
            await _repository.UpdateAsync(exam);
            var result = _mapper.Map<UpdatedExamResponse>(exam);
            return result;
        }

        public async Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest)
        {
            var exam = await _repository.GetAsync(e => e.Id == deleteExamRequest.Id);
            var deletedExam = await _repository.DeleteAsync(exam);
            var result = _mapper.Map<DeletedExamResponse>(deletedExam);
            return result;
        }

        public async Task<GetListExamInfoResponse> GetInfoById(int id)
        {
            var exam = await _repository.GetAsync(e => e.Id == id);
            var result = _mapper.Map<GetListExamInfoResponse>(exam);
            return result;
        }


        public async Task<List<GetListExamResponse>> GetExamsByCourseId(int courseId)
        {
            var exams = await _repository.GetListAsync(e => e.CourseId == courseId);
            var result = _mapper.Map<List<GetListExamResponse>>(exams);
            return result;
        }
    }
}
