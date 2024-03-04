using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Request.StudentLesson;
using Business.DTOs.Response.Course;
using Business.DTOs.Response.StudentCourse;
using Business.DTOs.Response.StudentLesson;
using Business.DTOs.Response.UserLanguage;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes.CoursesFolder;
using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NRedisStack.Graph;
using Serilog;

namespace Business.Concretes
{
    public class StudentCourseManager : IStudentCourseService
    {
        IStudentCourseDal _studentCourseDal;
        IMapper _mapper;
        StudentCourseBusinessRules _businessRules;
        IStudentService _studentService;
        IStudentLessonService _studentLessonService;
        ILessonService _lessonService;
        ICourseService _courseService;
        public StudentCourseManager(IStudentCourseDal studentCourseDal, IMapper mapper, StudentCourseBusinessRules businessRules, IStudentService studentService, IStudentLessonService studentLessonService, ILessonService lessonService, ICourseService courseService)
        {
            _studentCourseDal = studentCourseDal;
            _mapper = mapper;
            _businessRules = businessRules;
            _studentService = studentService;
            _studentLessonService = studentLessonService;
            _lessonService = lessonService;
            _courseService = courseService;
        }

        public async Task<CreatedStudentCourseResponse> Add(CreateStudentCourseRequest createStudentCourseRequest)
        {
            try
            {
                StudentCourse studentCourse = _mapper.Map<StudentCourse>(createStudentCourseRequest);
                StudentCourse createdStudentCourse = await _studentCourseDal.AddAsync(studentCourse);

                var lessonsOfCourses = await _lessonService.GetListCoursesAllLessonsAsync(createStudentCourseRequest.CourseId);

                foreach (var lesson in lessonsOfCourses)
                {
                    CreateStudentLessonRequest studentLessonRequest = new CreateStudentLessonRequest
                    {
                        LessonId = lesson.Id,
                        StudentId = createStudentCourseRequest.StudentId,
                        Progress = 0,
                        IsLiked = false
                    };
                    await _studentLessonService.Add(studentLessonRequest);
                }

                CreatedStudentCourseResponse createdStudentCourseResponse = _mapper.Map<CreatedStudentCourseResponse>(createdStudentCourse);
                Log.Information("StudentCourse added successfully. ID: {StudentCourseId}", createdStudentCourse.Id);

                return createdStudentCourseResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "An error occurred while adding a StudentCourse");
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

        public async Task<List<GeneralStudentCourseList>> GetStudentsAllCoursesByUserId(Guid userId)
        {
            var student = _studentService.GetStudentByUserId(userId);

            var allCourses = await _studentCourseDal.GetListAsync(predicate: sc=>sc.StudentId==student.Id,
                                                                    include:query=>query
                                                                    .Include(sc => sc.Student)
                                                                    .Include(sc=>sc.Course));

            var result = _mapper.Map<List<GeneralStudentCourseList>>(allCourses);
            return result;
        }

        public async Task<List<GeneralStudentCourseList>> GetStudentsOngoingCoursesByUserId(Guid userId)
        {
            var student = _studentService.GetStudentByUserId(userId);

            var ongoingCourses = await _studentCourseDal.GetListAsync(
                                                              predicate: sc => sc.StudentId == student.Id && sc.Progress < 100,
                                                              include: query => query
                                                              .Include(sc => sc.Student)
                                                              .Include(sc => sc.Course));

            var results = _mapper.Map<List<GeneralStudentCourseList>>(ongoingCourses);

            return results;
        }
        public async Task<List<GeneralStudentCourseList>> GetStudentsCompletedCoursesByUserId(Guid userId)
        {
            var student = _studentService.GetStudentByUserId(userId);

            var completedCourses = await _studentCourseDal.GetListAsync(
                                                              predicate: sc => sc.StudentId == student.Id && sc.Progress == 100,
                                                              include: query => query
                                                              .Include(sc => sc.Student)
                                                              .Include(sc => sc.Course));

            var results = _mapper.Map<List<GeneralStudentCourseList>>(completedCourses);

            return results;
        }

        public async Task<CoursesAllLessonInfoResponse> GetStudentsCourseAllInfo(int studentCourseId)
        {
                var studentsCourse = await _studentCourseDal.GetAsync(predicate: sc => sc.Id == studentCourseId,
                                                                            include: query => query
                                                                            .Include(sc => sc.Student)
                                                                            .ThenInclude(sc => sc.StudentLessons)
                                                                            .Include(sc => sc.Course)
                                                                            .ThenInclude(course => course.Lessons));

                var results = _mapper.Map<CoursesAllLessonInfoResponse>(studentsCourse);
                return results;      
        }

        public async Task<int> GetIsLikedCountByCourseIdAsync(int courseId)
        {
            var studentCourses = await _studentCourseDal.GetListAsync(
                l => l.CourseId == courseId && l.Liked == 1
            );

            var listStudentCourses = studentCourses.Items;

            var likecount = listStudentCourses.Count();

            return likecount;

        }
        public async Task<List<GeneralStudentCourseList>> GetListStudentsNotRegisteredCourses(Guid studentId)
        {
            var allCourses = await _courseService.GetListAllCoursesAsync();

            var data = await _studentCourseDal.GetListAsync(predicate: sc => sc.StudentId == studentId,
                                                        include: query => query
                                                        .Include(s => s.Course));
            var registeredCourses = data.Items;

            var mappedAllCourses = _mapper.Map<List<GeneralStudentCourseList>>(allCourses);

            var mappedRegisteredCourses = _mapper.Map<List<GeneralStudentCourseList>>(registeredCourses);

            var notRegisteredCourses = mappedAllCourses.Where(course => !mappedRegisteredCourses.Any(rc => rc.CourseId == course.CourseId)).ToList();

            return notRegisteredCourses;
        }

    }
}
