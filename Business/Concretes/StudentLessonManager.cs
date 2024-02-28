using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.StudentLesson;
using Business.DTOs.Response.StudentLesson;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class StudentLessonManager : IStudentLessonService
    {
        IStudentLessonDal _studentLessonDal;
        IMapper _mapper;

        public StudentLessonManager(IStudentLessonDal studentLessonDal, IMapper mapper)
        {
            _studentLessonDal = studentLessonDal;
            _mapper = mapper;
        }

        public async Task<CreatedStudentLessonResponse> Add(CreateStudentLessonRequest createStudentLessonRequest)
        {
            StudentLesson studentLesson = _mapper.Map<StudentLesson>(createStudentLessonRequest);
            StudentLesson createdStudentLesson = await _studentLessonDal.AddAsync(studentLesson);
            CreatedStudentLessonResponse createdStudentLessonResponse = _mapper.Map<CreatedStudentLessonResponse>(createdStudentLesson);
            return createdStudentLessonResponse;
        }

        public async Task<DeletedStudentLessonResponse> Delete(DeleteStudentLessonRequest deleteStudentLessonRequest)
        {
            var data = await _studentLessonDal.GetAsync(i => i.Id == deleteStudentLessonRequest.Id);
            _mapper.Map(deleteStudentLessonRequest, data);
            var result = await _studentLessonDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedStudentLessonResponse>(result);
            return result2;
        }

        public async Task<CreatedStudentLessonResponse> GetById(int id)
        {
            var result = await _studentLessonDal.GetAsync(c => c.Id == id);
            StudentLesson mappedStudentLesson = _mapper.Map<StudentLesson>(result);
            CreatedStudentLessonResponse createdStudentLessonResponse = _mapper.Map<CreatedStudentLessonResponse>(mappedStudentLesson);
            return createdStudentLessonResponse;
        }


        public async Task<IPaginate<GetListStudentLessonResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _studentLessonDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListStudentLessonResponse>>(data);
            return result;
        }


        public async Task<UpdatedStudentLessonResponse> Update(UpdateStudentLessonRequest updateStudentLessonRequest)
        {
            var data = await _studentLessonDal.GetAsync(i => i.Id == updateStudentLessonRequest.Id);
            _mapper.Map(updateStudentLessonRequest, data);
            await _studentLessonDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedStudentLessonResponse>(data);
            return result;
        }
    }

}
