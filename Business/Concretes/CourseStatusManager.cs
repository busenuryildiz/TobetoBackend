using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.CourseStatus;
using Business.DTOs.Response.CourseStatus;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;

namespace Business.Concretes
{


    public class CourseStatusManager : ICourseStatusService
    {
        ICourseStatusDal _CourseStatusDal;
        IMapper _mapper;
        CourseStatusBusinessRules _businessRules;

        public CourseStatusManager(CourseStatusBusinessRules businessRules, ICourseStatusDal CourseStatusDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _CourseStatusDal = CourseStatusDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseStatusResponse> Add(CreateCourseStatusRequest createCourseStatusRequest)
        {
            CourseStatus CourseStatus = _mapper.Map<CourseStatus>(createCourseStatusRequest);
            CourseStatus createdCourseStatus = await _CourseStatusDal.AddAsync(CourseStatus);
            CreatedCourseStatusResponse createdCourseStatusResponse = _mapper.Map<CreatedCourseStatusResponse>(createdCourseStatus);
            return createdCourseStatusResponse;
        }

        public async Task<DeletedCourseStatusResponse> Delete(DeleteCourseStatusRequest deleteCourseStatusRequest)
        {
            var data = await _CourseStatusDal.GetAsync(i => i.Id == deleteCourseStatusRequest.Id);
            _mapper.Map(deleteCourseStatusRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _CourseStatusDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedCourseStatusResponse>(result);
            return result2;
        }

        public async Task<CreatedCourseStatusResponse> GetById(int id)
        {
            var result = await _CourseStatusDal.GetAsync(c => c.Id == id);
            CourseStatus mappedCourseStatus = _mapper.Map<CourseStatus>(result);

            CreatedCourseStatusResponse createdCourseStatusResponse = _mapper.Map<CreatedCourseStatusResponse>(mappedCourseStatus);

            return createdCourseStatusResponse;
        }


        public async Task<IPaginate<GetListCourseStatusResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _CourseStatusDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCourseStatusResponse>>(data);
            return result;
        }


        public async Task<UpdatedCourseStatusResponse> Update(UpdateCourseStatusRequest updateCourseStatusRequest)
        {
            var data = await _CourseStatusDal.GetAsync(i => i.Id == updateCourseStatusRequest.Id);
            _mapper.Map(updateCourseStatusRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _CourseStatusDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCourseStatusResponse>(data);
            return result;
        }
    }

}
