using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Classroom;
using Business.DTOs.Response.Classroom;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;

namespace Business.Concretes
{
    public class ClassroomManager : IClassroomService
    {
        IClassroomDal _classroomDal;
        IMapper _mapper;

        public ClassroomManager(IClassroomDal classroomDal, IMapper mapper)
        {
            _classroomDal = classroomDal;
            _mapper = mapper;
        }

        public async Task<CreatedClassroomResponse> Add(CreateClassroomRequest createClassroomRequest)
        {
            Classroom classroom = _mapper.Map<Classroom>(createClassroomRequest);
            Classroom createdClassroom = await _classroomDal.AddAsync(classroom);
            CreatedClassroomResponse createdClassroomResponse = _mapper.Map<CreatedClassroomResponse>(createdClassroom);
            return createdClassroomResponse;
        }

        public async Task<DeletedClassroomResponse> Delete(DeleteClassroomRequest deleteClassroomRequest)
        {
            var data = await _classroomDal.GetAsync(i => i.Id == deleteClassroomRequest.Id);
            _mapper.Map(deleteClassroomRequest, data);
            var result = await _classroomDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedClassroomResponse>(result);
            return result2;
        }

        public async Task<CreatedClassroomResponse> GetById(int id)
        {
            var result = await _classroomDal.GetAsync(c => c.Id == id);
            Classroom mappedClassroom = _mapper.Map<Classroom>(result);
            CreatedClassroomResponse createdClassroomResponse = _mapper.Map<CreatedClassroomResponse>(mappedClassroom);
            return createdClassroomResponse;
        }


        public async Task<IPaginate<GetListClassroomResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _classroomDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListClassroomResponse>>(data);
            return result;
        }


        public async Task<UpdatedClassroomResponse> Update(UpdateClassroomRequest updateClassroomRequest)
        {
            var data = await _classroomDal.GetAsync(i => i.Id == updateClassroomRequest.Id);
            _mapper.Map(updateClassroomRequest, data);
            await _classroomDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedClassroomResponse>(data);
            return result;
        }
    }
}
