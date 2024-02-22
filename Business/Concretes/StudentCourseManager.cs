using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Response.StudentCourse;
using Business.DTOs.Response.UserLanguage;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes.CoursesFolder;
using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Business.Concretes
{
    public class StudentCourseManager : IStudentCourseService
    {
        IStudentCourseDal _studentCourseDal;
        IMapper _mapper;
        StudentCourseBusinessRules _businessRules;
        IStudentService _studentService;

        public StudentCourseManager(IStudentCourseDal studentCourseDal, IMapper mapper, StudentCourseBusinessRules businessRules, IStudentService studentService)
        {
            _studentCourseDal = studentCourseDal;
            _mapper = mapper;
            _businessRules = businessRules;
            _studentService = studentService;
        }

        public async Task<CreatedStudentCourseResponse> Add(CreateStudentCourseRequest createStudentCourseRequest)
        {
            try
            {
                // Validate createStudentCourseRequest if necessary

                // DTO to Entity mapping
                StudentCourse studentCourse = _mapper.Map<StudentCourse>(createStudentCourseRequest);

                // Add the StudentCourse to the database
                StudentCourse createdStudentCourse = await _studentCourseDal.AddAsync(studentCourse);

                // Entity to DTO mapping for the response
                CreatedStudentCourseResponse createdStudentCourseResponse = _mapper.Map<CreatedStudentCourseResponse>(createdStudentCourse);

                // Log success or any additional information
                Log.Information("StudentCourse added successfully. ID: {StudentCourseId}", createdStudentCourse.Id);
                // Return the response
                return createdStudentCourseResponse;
            }
            catch (Exception ex)
            {
                // Log the error
                Log.Error(ex.Message, "An error occurred while adding a StudentCourse");

                // Rethrow the exception or handle it based on your requirements
                throw;
            }
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


            try
            {
                var data = await _studentCourseDal.GetListAsync(
                    index: pageRequest.PageIndex,
                    size: pageRequest.PageSize,
                    include: sc => sc.Include(sc => sc.Course)
                );


                Log.Information("data", data);

                var result = _mapper.Map<Paginate<GetListStudentCourseResponse>>(data);
                return result;
            }
            catch (Exception ex)
            {
                // Log the error
                Log.Information(ex.Message, "An error occurred while fetching the list of StudentCourses");

                // Rethrow the exception or handle it based on your requirements
                throw;
            }
        }


        public async Task<CreatedStudentCourseResponse> GetCertificateByExamAndStudentCourseId(int examId, int studentCourseId)
        {
            //await _businessRules.CertificateCanNotBeGivenDueToProgress(examId, studentCourseId);
            var result = await _studentCourseDal.GetAsync(c => c.Id == studentCourseId);
            StudentCourse mappedStudentCourse = _mapper.Map<StudentCourse>(result);
            CreatedStudentCourseResponse createdStudentCourseResponse = _mapper.Map<CreatedStudentCourseResponse>(mappedStudentCourse);
            return createdStudentCourseResponse;
        }

        public async Task<IPaginate<GetListStudentCourseResponse>> GetListAsync(Guid studentId, PageRequest pageRequest)
        {
            try
            {
                var data = await _studentCourseDal.GetListAsync(
                    predicate: sc => sc.StudentId == studentId, // Sadece belirli öğrencinin verilerini getir
                    index: pageRequest.PageIndex,
                    size: pageRequest.PageSize,
                    include: sc => sc.Include(sc => sc.Course)
                );

                Log.Information("Fetched data for StudentId {StudentId}: {@Data}", studentId, data);

                var result = _mapper.Map<Paginate<GetListStudentCourseResponse>>(data);
                return result;
            }
            catch (Exception ex)
            {
                // Log the error
                Log.Error(ex, "An error occurred while fetching the list of StudentCourses for StudentId {StudentId}", studentId);

                // Rethrow the exception or handle it based on your requirements
                throw;
            }
        }

        public async Task<List<GetUserBadgesResponse>> GetBadgesForCompletedCourses(Guid userId)
        {
            var student = _studentService.GetStudentByUserId(userId);

            var completedCourses = await _studentCourseDal.GetListAsync(
                                                              predicate: sc => sc.StudentId == student.Id && sc.Progress == 100,
                                                              include: query => query
                                                              .Include(sc => sc.Student)
                                                              .Include(sc => sc.Course));

            var results = _mapper.Map<List<GetUserBadgesResponse>>(completedCourses);

            return results;

        }
    }
}
