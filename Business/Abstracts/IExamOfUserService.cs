using Business.DTOs.Request.ExamOfUser;
using Business.DTOs.Response.ExamOfUser;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

    public interface IExamOfUserService
    {
        Task<IPaginate<GetListExamOfUserResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedExamOfUserResponse> Add(CreateExamOfUserRequest createExamOfUserRequest);
        Task<UpdatedExamOfUserResponse> Update(UpdateExamOfUserRequest updateExamOfUserRequest);
        Task<DeletedExamOfUserResponse> Delete(DeleteExamOfUserRequest deleteExamOfUserRequest);
        Task<CreatedExamOfUserResponse> GetById(int id);
        Task<IPaginate<GetUsersExamResultInfoResponse>> GetUsersExamResultInfo(Guid userId, int value);


}

