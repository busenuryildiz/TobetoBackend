using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Subject;
using Business.DTOs.Response.Subject;
using Core.Aspects.Autofac.Logging;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

public class SubjectManager : ISubjectService
{
    private readonly ISubjectDal _repository;
    private readonly IMapper _mapper;

    public SubjectManager(ISubjectDal repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    [LogAspect]
    public async Task<CreatedSubjectResponse> Add(CreateSubjectRequest createSubjectRequest)
    {
        var subject = _mapper.Map<Subject>(createSubjectRequest);
        var createdSubject = await _repository.AddAsync(subject);
        return _mapper.Map<CreatedSubjectResponse>(createdSubject);
    }

    public async Task<DeletedSubjectResponse> Delete(DeleteSubjectRequest deleteSubjectRequest)
    {
        var subject = await _repository.GetAsync(s => s.Id == deleteSubjectRequest.Id);
        var deletedSubject = await _repository.DeleteAsync(subject);
        return _mapper.Map<DeletedSubjectResponse>(deletedSubject);
    }

    public async Task<UpdatedSubjectResponse> Update(UpdateSubjectRequest updateSubjectRequest)
    {
        var subject = await _repository.GetAsync(s => s.Id == updateSubjectRequest.Id);
        _mapper.Map(updateSubjectRequest, subject);
        await _repository.UpdateAsync(subject);
        return _mapper.Map<UpdatedSubjectResponse>(subject);
    }

    public async Task<GetByIdSubjectResponse> GetById(int id)
    {
        var subject = await _repository.GetAsync(s => s.Id == id);
        return _mapper.Map<GetByIdSubjectResponse>(subject);
    }

    public async Task<IPaginate<GetListSubjectInfoResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _repository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
        return _mapper.Map<Paginate<GetListSubjectInfoResponse>>(data);
    }
}