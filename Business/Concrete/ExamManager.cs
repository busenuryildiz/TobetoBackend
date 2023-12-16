using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete.Course;

namespace Business.Concrete
{
    public class ExamManager : IExamService
    {
        IExamDal _examDal;
        IMapper _mapper;
        ExamBusinessRules _examBusinessRules;

        public ExamManager(IExamDal examDal, IMapper mapper, ExamBusinessRules examBusinessRules)
        {
            _examDal = examDal;
            _mapper = mapper;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest)
        {
            var mappedRequest = _mapper.Map<Exam>(createExamRequest);
            var createdRequest = await _examDal.AddAsync(mappedRequest);
            var createdResponse = _mapper.Map<CreatedExamResponse>(createdRequest);
            return createdResponse;
        }

        public async Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest)
        {
            var mappedRequest = _mapper.Map<Exam>(deleteExamRequest);
            var createdRequest = await _examDal.DeleteAsync(mappedRequest);
            var createdResponse = _mapper.Map<DeletedExamResponse>(createdRequest);
            return createdResponse;
        }

        public async Task<CreatedExamResponse> GetById(Guid id)
        {
            var result = await _examDal.GetAsync(e => e.Id == id);
            var mappedResult = _mapper.Map<Exam>(result);
            var createdResponse = _mapper.Map<CreatedExamResponse>(mappedResult);

            return createdResponse;
        }

        public async Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _examDal.GetListAsync();

            var result = _mapper.Map<Paginate<GetListExamResponse>>(data);

            return result;
        }

        public async Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest)
        {
            var mappedRequest = _mapper.Map<Exam>(updateExamRequest);

            var updatedRequest = await _examDal.UpdateAsync(mappedRequest);

            var updatedResponse = _mapper.Map<UpdatedExamResponse>(updatedRequest);

            return updatedResponse;
        }
    }
}
