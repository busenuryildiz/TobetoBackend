using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.CoursePart;
using Business.DTOs.Response.CoursePart;
using Core.Aspects.Autofac.Logging;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.CoursesFolder;

public class CoursePartManager : ICoursePartService
{
    private readonly ICoursePartDal _repository;
    private readonly IMapper _mapper;

    public CoursePartManager(ICoursePartDal repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [LogAspect]
    public async Task<CreatedCoursePartResponse> Add(CreateCoursePartRequest createCoursePartRequest)
    {
        var coursePart = _mapper.Map<CoursePart>(createCoursePartRequest);
        var createdCoursePart = await _repository.AddAsync(coursePart);
        return _mapper.Map<CreatedCoursePartResponse>(createdCoursePart);
    }

    public async Task<DeletedCoursePartResponse> Delete(DeleteCoursePartRequest deleteCoursePartRequest)
    {
        var coursePart = await _repository.GetAsync(cp => cp.Id == deleteCoursePartRequest.Id);
        var deletedCoursePart = await _repository.DeleteAsync(coursePart);
        return _mapper.Map<DeletedCoursePartResponse>(deletedCoursePart);
    }

    public async Task<UpdatedCoursePartResponse> Update(UpdateCoursePartRequest updateCoursePartRequest)
    {
        var coursePart = await _repository.GetAsync(cp => cp.Id == updateCoursePartRequest.Id);
        _mapper.Map(updateCoursePartRequest, coursePart);
        await _repository.UpdateAsync(coursePart);
        return _mapper.Map<UpdatedCoursePartResponse>(coursePart);
    }

    public async Task<GetCoursePartByIdResponse> GetById(int id)
    {
        var coursePart = await _repository.GetAsync(cp => cp.Id == id);
        return _mapper.Map<GetCoursePartByIdResponse>(coursePart);
    }

    public async Task<IPaginate<GetListCoursePartResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _repository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
        return _mapper.Map<Paginate<GetListCoursePartResponse>>(data);
    }
}
