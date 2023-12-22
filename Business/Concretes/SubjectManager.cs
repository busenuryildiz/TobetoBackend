using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Subject;
using Business.DTOs.Request.Subject;
using Business.DTOs.Response.Subject;
using Business.DTOs.Response.Subject;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

public class SubjectManager : ISubjectService
{
    ISubjectDal _blogDal;
    IMapper _mapper;
    SubjectBusinessRules _businessRules;

    public SubjectManager(SubjectBusinessRules businessRules, ISubjectDal blogDal, IMapper mapper)
    {
        _businessRules = businessRules;
        _blogDal = blogDal;
        _mapper = mapper;
    }

    public async Task<CreatedSubjectResponse> Add(CreateSubjectRequest createSubjectRequest)
    {
        Subject blog = _mapper.Map<Subject>(createSubjectRequest);
        Subject createdSubject = await _blogDal.AddAsync(blog);
        CreatedSubjectResponse createdSubjectResponse = _mapper.Map<CreatedSubjectResponse>(createdSubject);
        return createdSubjectResponse;
    }

    public async Task<DeletedSubjectResponse> Delete(DeleteSubjectRequest deleteSubjectRequest)
    {
        var data = await _blogDal.GetAsync(i => i.Id == deleteSubjectRequest.Id);
        _mapper.Map(deleteSubjectRequest, data);
        data.DeletedDate = DateTime.Now;
        var result = await _blogDal.DeleteAsync(data, true);
        var result2 = _mapper.Map<DeletedSubjectResponse>(result);
        return result2;
    }

    public async Task<CreatedSubjectResponse> GetById(int id)
    {
        var result = await _blogDal.GetAsync(c => c.Id == id);
        Subject mappedSubject = _mapper.Map<Subject>(result);
        CreatedSubjectResponse createdSubjectResponse = _mapper.Map<CreatedSubjectResponse>(mappedSubject);
        return createdSubjectResponse;
    }


    public async Task<IPaginate<GetListSubjectResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _blogDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );
        var result = _mapper.Map<Paginate<GetListSubjectResponse>>(data);
        return result;
    }


    public async Task<UpdatedSubjectResponse> Update(UpdateSubjectRequest updateSubjectRequest)
    {
        var data = await _blogDal.GetAsync(i => i.Id == updateSubjectRequest.Id);
        _mapper.Map(updateSubjectRequest, data);
        data.UpdatedDate = DateTime.Now;
        await _blogDal.UpdateAsync(data);
        var result = _mapper.Map<UpdatedSubjectResponse>(data);
        return result;
    }
}