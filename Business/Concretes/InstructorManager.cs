using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Instructor;
using Business.DTOs.Response.Instructor;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        IMapper _mapper;
        InstructorBusinessRules _businessRules;
        public InstructorManager(IInstructorDal instructorDal, IMapper mapper, InstructorBusinessRules businessRules)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
            Instructor createdInstructor = await _instructorDal.AddAsync(instructor);
            CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(createdInstructor);
            return createdInstructorResponse;
        }

        public async Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest)
        {
            var data = await _instructorDal.GetAsync(i => i.Id == deleteInstructorRequest.Id);
            _mapper.Map(deleteInstructorRequest, data);
            var result = await _instructorDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedInstructorResponse>(result);
            return result2;
        }

        public async Task<CreatedInstructorResponse> GetById(Guid id)
        {
            var result = await _instructorDal.GetAsync(c => c.Id == id);
            Instructor mappedInstructor = _mapper.Map<Instructor>(result);
            CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(mappedInstructor);
            return createdInstructorResponse;
        }


        public async Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _instructorDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListInstructorResponse>>(data);
            return result;
        }


        public async Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest)
        {
            var data = await _instructorDal.GetAsync(i => i.Id == updateInstructorRequest.Id);
            _mapper.Map(updateInstructorRequest, data);
            await _instructorDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedInstructorResponse>(data);
            return result;
        }
    }
}
