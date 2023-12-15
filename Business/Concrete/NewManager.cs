using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NewManager : INewService
    {
        INewDal _newDal;
        IMapper _mapper;
        NewBusinessRules _newBusinessRules;

        public NewManager(INewDal newDal, IMapper mapper, NewBusinessRules newBusinessRules)
        {
            _newDal = newDal;
            _mapper = mapper;
            _newBusinessRules = newBusinessRules;
        }

        public async Task<CreatedNewResponse> Add(CreateNewRequest createNewRequest)
        {
            var mappedRequest = _mapper.Map<New>(createNewRequest);
            var createdRequest = await _newDal.AddAsync(mappedRequest);
            var createdResponse = _mapper.Map<CreatedNewResponse>(createdRequest);
            return createdResponse;
        }

        public async Task<DeletedNewResponse> Delete(DeleteNewRequest deleteNewRequest)
        {
            var mappedRequest = _mapper.Map<New>(deleteNewRequest);
            var createdRequest = await _newDal.DeleteAsync(mappedRequest);
            var createdResponse = _mapper.Map<DeletedNewResponse>(createdRequest);
            return createdResponse;
        }

        public async Task<CreatedNewResponse> GetById(Guid id)
        {
            var result = await _newDal.GetAsync(n=> n.Id == id);
            var mappedResult = _mapper.Map<New>(result);
            var createdResponse = _mapper.Map<CreatedNewResponse>(mappedResult);

            return createdResponse;
        }

        public async Task<IPaginate<GetListNewResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _newDal.GetListAsync();

            var result = _mapper.Map<Paginate<GetListNewResponse>>(data);

            return result;
        }

        public async Task<UpdatedNewResponse> Update(UpdateNewRequest updateNewRequest)
        {
            var mappedRequest = _mapper.Map<New>(updateNewRequest);

            var updatedRequest = await _newDal.UpdateAsync(mappedRequest);

            var updatedResponse = _mapper.Map<UpdatedNewResponse>(updatedRequest);

            return updatedResponse;
        }
    }
}
