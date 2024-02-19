using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.ExamOfUser;
using Business.DTOs.Response.Exam;
using Business.DTOs.Response.ExamOfUser;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{

    public class ExamOfUserManager : IExamOfUserService
    {
        IExamOfUserDal _examOfUserDal;
        IMapper _mapper;

        public ExamOfUserManager(IExamOfUserDal examOfUserDal, IMapper mapper)
        {
            _examOfUserDal = examOfUserDal;
            _mapper = mapper;
        }

        public async Task<CreatedExamOfUserResponse> Add(CreateExamOfUserRequest createExamOfUserRequest)
        {
            ExamOfUser examOfUser = _mapper.Map<ExamOfUser>(createExamOfUserRequest);
            ExamOfUser createdExamOfUser = await _examOfUserDal.AddAsync(examOfUser);
            CreatedExamOfUserResponse createdExamOfUserResponse = _mapper.Map<CreatedExamOfUserResponse>(createdExamOfUser);
            return createdExamOfUserResponse;
        }

        public async Task<DeletedExamOfUserResponse> Delete(DeleteExamOfUserRequest deleteExamOfUserRequest)
        {
            var data = await _examOfUserDal.GetAsync(i => i.Id == deleteExamOfUserRequest.Id);
            _mapper.Map(deleteExamOfUserRequest, data);
            var result = await _examOfUserDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedExamOfUserResponse>(result);
            return result2;
        }

        public async Task<CreatedExamOfUserResponse> GetById(int id)
        {
            var result = await _examOfUserDal.GetAsync(c => c.Id == id);
            ExamOfUser mappedExamOfUser = _mapper.Map<ExamOfUser>(result);
            CreatedExamOfUserResponse createdExamOfUserResponse = _mapper.Map<CreatedExamOfUserResponse>(mappedExamOfUser);
            return createdExamOfUserResponse;
        }


        public async Task<IPaginate<GetListExamOfUserResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _examOfUserDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListExamOfUserResponse>>(data);
            return result;
        }


        public async Task<UpdatedExamOfUserResponse> Update(UpdateExamOfUserRequest updateExamOfUserRequest)
        {
            var data = await _examOfUserDal.GetAsync(i => i.Id == updateExamOfUserRequest.Id);
            _mapper.Map(updateExamOfUserRequest, data);
            await _examOfUserDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedExamOfUserResponse>(data);
            return result;
        }

        public async Task<IPaginate<GetUsersExamResultInfoResponse>> GetUsersExamResultInfo(Guid userId, int value)
        {
            var userExamInfo = await _examOfUserDal.GetListAsync(e => e.UserId == userId,
                                                                    include: query => query
                                                                    .Include(u => u.Exam),
                                                                    size: value);

            var result = _mapper.Map<Paginate<GetUsersExamResultInfoResponse>>(userExamInfo);

            return result;
        }
    }
}