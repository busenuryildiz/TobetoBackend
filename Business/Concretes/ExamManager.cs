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
        private readonly IExamDal _examDal;
        private readonly IMapper _mapper;

        public ExamManager(IExamDal examDal, IMapper mapper)
        {
            _examDal = examDal;
            _mapper = mapper;
        }

        public async Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(createExamRequest);
            Exam createdExam = await _examDal.AddAsync(exam);
            CreatedExamResponse createdExamResponse = _mapper.Map<CreatedExamResponse>(createdExam);
            return createdExamResponse;
        }

        public async Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest)
        {
            var data = await _examDal.GetAsync(i => i.Id == deleteExamRequest.Id);
            _mapper.Map(deleteExamRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _examDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedExamResponse>(result);
            return result2;
        }

        public async Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest)
        {
            var data = await _examDal.GetAsync(i => i.Id == updateExamRequest.Id);
            _mapper.Map(updateExamRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _examDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedExamResponse>(data);
            return result;
        }

        public async Task<GetByIdExamResponse> GetById(int id)
        {
            var result = await _examDal.GetAsync(c => c.Id == id);
            Exam mappedExam = _mapper.Map<Exam>(result);

            GetByIdExamResponse getByIdExamResponse = _mapper.Map<GetByIdExamResponse>(mappedExam);

            return getByIdExamResponse;
        }

        public async Task<IPaginate<GetListExamInfoResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _examDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListExamInfoResponse>>(data);
            return result;
        }
    }
}
