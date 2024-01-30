using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Lesson;
using Business.DTOs.Response.Lesson;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;

namespace Business.Concretes
{
    public class LessonManager : ILessonService
    {
        ILessonDal _LessonDal;
        IMapper _mapper;
        LessonBusinessRules _businessRules;

        public LessonManager(LessonBusinessRules businessRules, ILessonDal LessonDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _LessonDal = LessonDal;
            _mapper = mapper;
        }

        public async Task<CreatedLessonResponse> Add(CreateLessonRequest createLessonRequest)
        {
            Lesson lesson = _mapper.Map<Lesson>(createLessonRequest);
            Lesson createdLesson = await _LessonDal.AddAsync(lesson);
            CreatedLessonResponse createdLessonResponse = _mapper.Map<CreatedLessonResponse>(createdLesson);
            return createdLessonResponse;
        }

        public async Task<DeletedLessonResponse> Delete(DeleteLessonRequest deleteLessonRequest)
        {
            var data = await _LessonDal.GetAsync(i => i.Id == deleteLessonRequest.Id);
            _mapper.Map(deleteLessonRequest, data);
            var result = await _LessonDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedLessonResponse>(result);
            return result2;
        }

        public async Task<CreatedLessonResponse> GetById(int id)
        {
            var result = await _LessonDal.GetAsync(c => c.Id == id);
            Lesson mappedLesson = _mapper.Map<Lesson>(result);
            CreatedLessonResponse createdLessonResponse = _mapper.Map<CreatedLessonResponse>(mappedLesson);
            return createdLessonResponse;
        }


        public async Task<IPaginate<GetListLessonResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _LessonDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListLessonResponse>>(data);
            return result;
        }


        public async Task<UpdatedLessonResponse> Update(UpdateLessonRequest updateLessonRequest)
        {
            var data = await _LessonDal.GetAsync(i => i.Id == updateLessonRequest.Id);
            _mapper.Map(updateLessonRequest, data);
            await _LessonDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedLessonResponse>(data);
            return result;
        }
    }
}

