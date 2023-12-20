using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Subject;
using Business.DTOs.Response.Subject;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

public class SubjectManager : ISubjectService
{
    private readonly ISubjectDal _subjectDal;
    private readonly IMapper _mapper;

    public SubjectManager(ISubjectDal subjectDal, IMapper mapper)
    {
        _subjectDal = subjectDal ?? throw new ArgumentNullException(nameof(subjectDal));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IPaginate<SubjectResponse>> GetAllSubjectsAsync(PageRequest pageRequest)
    {
        var subjects = await _subjectDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );

        // Map the subjects to SubjectResponse
        var result = _mapper.Map<Paginate<SubjectResponse>>(subjects);

        return result;
    }

    public async Task<SubjectResponse> AddSubjectAsync(CreateSubjectRequest request)
    {
        var newSubject = _mapper.Map<Subject>(request);
        var addedSubject = await _subjectDal.AddAsync(newSubject);
        return _mapper.Map<SubjectResponse>(addedSubject);
    }

    public async Task<IEnumerable<SubjectResponse>> GetAllSubjectsAsync()
    {
        var subjects = await _subjectDal.GetListAsync();
        return _mapper.Map<IEnumerable<SubjectResponse>>(subjects);
    }

    public async Task<SubjectResponse> GetSubjectByIdAsync(int id)
    {
        var subject = await _subjectDal.GetAsync(s => s.Id == id);
        return _mapper.Map<SubjectResponse>(subject);
    }

    public async Task<SubjectResponse> UpdateSubjectAsync(UpdateSubjectRequest request)
    {
        var existingSubject = await _subjectDal.GetAsync(s => s.Id == request.Id);

        if (existingSubject == null)
        {
            // Handle not found scenario, throw exception, or return null, etc.
            return null;
        }

        _mapper.Map(request, existingSubject);
        existingSubject.UpdatedDate = DateTime.Now;

        var updatedSubject = await _subjectDal.UpdateAsync(existingSubject);
        return _mapper.Map<SubjectResponse>(updatedSubject);
    }

    public async Task<bool> DeleteSubjectAsync(int id)
    {
        var existingSubject = await _subjectDal.GetAsync(s => s.Id == id);

        if (existingSubject == null)
        {
            // Handle not found scenario, throw exception, or return false, etc.
            return false;
        }

        var deletionResult = await _subjectDal.DeleteAsync(existingSubject);

        // Handle the deletionResult based on your specific needs
        return deletionResult != null; // Example check, customize based on your logic.
    }

    public async Task<IPaginate<SubjectResponse>> GetPagedSubjectsAsync(PageRequest pageRequest)
    {
        var pagedSubjects = await _subjectDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );

        // Map the pagedSubjects to Paginate<SubjectResponse>
        var result = _mapper.Map<Paginate<SubjectResponse>>(pagedSubjects);

        return result;
    }
}