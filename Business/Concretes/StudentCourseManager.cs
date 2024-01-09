using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Response.StudentCourse;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;

namespace Business.Concretes
{
    public class StudentCourseManager : IStudentCourseService
    {
        IStudentCourseDal _studentCourseDal;
        IMapper _mapper;
        StudentCourseBusinessRules _businessRules;

        public StudentCourseManager(IStudentCourseDal studentCourseDal, IMapper mapper, StudentCourseBusinessRules businessRules)
        {
            _studentCourseDal = studentCourseDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedStudentCourseResponse> Add(CreateStudentCourseRequest createStudentCourseRequest)
        {
            StudentCourse studentCourse = _mapper.Map<StudentCourse>(createStudentCourseRequest);
            StudentCourse createdStudentCourse = await _studentCourseDal.AddAsync(studentCourse);
            CreatedStudentCourseResponse createdStudentCourseResponse = _mapper.Map<CreatedStudentCourseResponse>(createdStudentCourse);
            return createdStudentCourseResponse;
        }

        public async Task<DeletedStudentCourseResponse> Delete(DeleteStudentCourseRequest deleteStudentCourseRequest)
        {
            var data = await _studentCourseDal.GetAsync(i => i.Id == deleteStudentCourseRequest.Id);
            _mapper.Map(deleteStudentCourseRequest, data);
            var result = await _studentCourseDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedStudentCourseResponse>(result);
            return result2;
        }

        public async Task<UpdatedStudentCourseResponse> Update(UpdateStudentCourseRequest updateStudentCourseRequest)
        {
            var data = await _studentCourseDal.GetAsync(i => i.Id == updateStudentCourseRequest.Id);
            _mapper.Map(updateStudentCourseRequest, data);
            await _studentCourseDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedStudentCourseResponse>(data);
            return result;
        }

        public async Task<CreatedStudentCourseResponse> GetById(int id)
        {
            var result = await _studentCourseDal.GetAsync(c => c.Id == id);
            StudentCourse mappedStudentCourse = _mapper.Map<StudentCourse>(result);
            CreatedStudentCourseResponse createdStudentCourseResponse = _mapper.Map<CreatedStudentCourseResponse>(mappedStudentCourse);
            return createdStudentCourseResponse;
        }

        public async Task<IPaginate<GetListStudentCourseResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _studentCourseDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListStudentCourseResponse>>(data);
            return result;
        }

        public async Task<CreatedStudentCourseResponse> GetCertificateByExamAndStudentCourseId(int examId, int studentCourseId)
        {
            //await _businessRules.CertificateCanNotBeGivenDueToProgress(examId, studentCourseId);
            var result = await _studentCourseDal.GetAsync(c => c.Id == studentCourseId);
            StudentCourse mappedStudentCourse = _mapper.Map<StudentCourse>(result);
            CreatedStudentCourseResponse createdStudentCourseResponse = _mapper.Map<CreatedStudentCourseResponse>(mappedStudentCourse);
            return createdStudentCourseResponse;
        }

    }
}
