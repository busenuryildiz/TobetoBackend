using Business.DTOs.Request.Classroom;
using Business.DTOs.Response.Classroom;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IClassroomService
    {
        Task<IPaginate<GetListClassroomResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedClassroomResponse> Add(CreateClassroomRequest createClassroomRequest);
        Task<UpdatedClassroomResponse> Update(UpdateClassroomRequest updateClassroomRequest);
        Task<DeletedClassroomResponse> Delete(DeleteClassroomRequest deleteClassroomRequest);
        Task<CreatedClassroomResponse> GetById(int id);
    }
}
