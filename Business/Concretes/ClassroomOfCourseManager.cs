using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.ClassroomOfCourse;
using Business.DTOs.Response.ClassroomOfCourse;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;

namespace Business.Concretes
{
    public class ClassroomOfCourseManager : IClassroomOfCourseService
    {
        IClassroomOfCourseDal _classroomOfCourseDal;
        IMapper _mapper;

        public ClassroomOfCourseManager(IClassroomOfCourseDal classroomOfCourseDal, IMapper mapper)
        {
            _classroomOfCourseDal = classroomOfCourseDal;
            _mapper = mapper;
        }

        public async Task<CreatedClassroomOfCourseResponse> Add(CreateClassroomOfCourseRequest createClassroomOfCourseRequest)
        {
            ClassroomOfCourse classroomOfCourse = _mapper.Map<ClassroomOfCourse>(createClassroomOfCourseRequest);
            ClassroomOfCourse createdClassroomOfCourse = await _classroomOfCourseDal.AddAsync(classroomOfCourse);
            CreatedClassroomOfCourseResponse createdClassroomOfCourseResponse = _mapper.Map<CreatedClassroomOfCourseResponse>(createdClassroomOfCourse);
            return createdClassroomOfCourseResponse;
        }

        public async Task<DeletedClassroomOfCourseResponse> Delete(DeleteClassroomOfCourseRequest deleteClassroomOfCourseRequest)
        {
            var data = await _classroomOfCourseDal.GetAsync(i => i.Id == deleteClassroomOfCourseRequest.Id);
            _mapper.Map(deleteClassroomOfCourseRequest, data);
            var result = await _classroomOfCourseDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedClassroomOfCourseResponse>(result);
            return result2;
        }

        public async Task<CreatedClassroomOfCourseResponse> GetById(int id)
        {
            var result = await _classroomOfCourseDal.GetAsync(c => c.Id == id);
            ClassroomOfCourse mappedClassroomOfCourse = _mapper.Map<ClassroomOfCourse>(result);
            CreatedClassroomOfCourseResponse createdClassroomOfCourseResponse = _mapper.Map<CreatedClassroomOfCourseResponse>(mappedClassroomOfCourse);
            return createdClassroomOfCourseResponse;
        }


        public async Task<IPaginate<GetListClassroomOfCourseResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _classroomOfCourseDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListClassroomOfCourseResponse>>(data);
            return result;
        }


        public async Task<UpdatedClassroomOfCourseResponse> Update(UpdateClassroomOfCourseRequest updateClassroomOfCourseRequest)
        {
            var data = await _classroomOfCourseDal.GetAsync(i => i.Id == updateClassroomOfCourseRequest.Id);
            _mapper.Map(updateClassroomOfCourseRequest, data);
            await _classroomOfCourseDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedClassroomOfCourseResponse>(data);
            return result;
        }
    }
}
