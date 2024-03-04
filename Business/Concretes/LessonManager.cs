using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Lesson;
using Business.DTOs.Response.Lesson;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;
        IMapper _mapper;
        LessonBusinessRules _businessRules;

        public LessonManager(LessonBusinessRules businessRules, ILessonDal LessonDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _lessonDal = LessonDal;
            _mapper = mapper;
        }

        public async Task<CreatedLessonResponse> Add(CreateLessonRequest createLessonRequest)
        {
            try
            {
                Lesson lesson = _mapper.Map<Lesson>(createLessonRequest);
                Lesson createdLesson = await _lessonDal.AddAsync(lesson);
                CreatedLessonResponse createdLessonResponse = _mapper.Map<CreatedLessonResponse>(createdLesson);
                return createdLessonResponse;
            }
            catch (Exception ex)
            {
                // InnerException'ı kontrol etmek için bir hata işleyici ekleyelim
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                // veya hata mesajını geri döndürerek istemciye iletebiliriz
                return null; // veya hata koduyla birlikte uygun bir hata mesajı döndürebilirsiniz
            }
        }

        public async Task<DeletedLessonResponse> Delete(DeleteLessonRequest deleteLessonRequest)
        {
            var data = await _lessonDal.GetAsync(i => i.Id == deleteLessonRequest.Id);
            _mapper.Map(deleteLessonRequest, data);
            var result = await _lessonDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedLessonResponse>(result);
            return result2;
        }

        public async Task<CreatedLessonResponse> GetById(int id)
        {
            var result = await _lessonDal.GetAsync(c => c.Id == id);
            Lesson mappedLesson = _mapper.Map<Lesson>(result);
            CreatedLessonResponse createdLessonResponse = _mapper.Map<CreatedLessonResponse>(mappedLesson);
            return createdLessonResponse;
        }


        public async Task<IPaginate<GetListLessonResponse>> GetListAsync(PageRequest pageRequest)
        {
            try
            {
                var data = await _lessonDal.GetListAsync(
                    index: pageRequest.PageIndex,
                    size: pageRequest.PageSize
                );
                var result = _mapper.Map<Paginate<GetListLessonResponse>>(data);
                return result;
            }
            catch (Exception ex)
            {
                // InnerException'ı kontrol etmek için bir hata işleyici ekleyelim
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                // veya hata mesajını geri döndürerek istemciye iletebiliriz
                return null; // veya hata koduyla birlikte uygun bir hata mesajı döndürebilirsiniz
            }
        }


        public async Task<UpdatedLessonResponse> Update(UpdateLessonRequest updateLessonRequest)
        {
            var data = await _lessonDal.GetAsync(i => i.Id == updateLessonRequest.Id);
            _mapper.Map(updateLessonRequest, data);
            await _lessonDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedLessonResponse>(data);
            return result;
        }

        public async Task<List<GetListCourseAndLessonInfoResponse>> GetAllCourseAndLessonInfo()
        {
            var data = await _lessonDal.GetListAsync(include: l => l
                                                        .Include(c => c.Course)
                                                        .ThenInclude(c => c.InstructorCourses)
                                                        .ThenInclude(c => c.Instructor)
                                                        .ThenInclude(c => c.User));
            var results = _mapper.Map<List<GetListCourseAndLessonInfoResponse>>(data);

            return results;
        }

        public async Task<List<GetListLessonResponse>> GetListCoursesAllLessonsAsync(int courseId)
        {
            var data = await _lessonDal.GetListAsync(predicate: l => l.CourseId == courseId);

            var lessonList = _mapper.Map<List<GetListLessonResponse>>(data.Items);

            return lessonList;
                                                                            
        }

    }
}

