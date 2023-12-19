using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Manager;
using Business.DTOs.Response.Manager;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;

namespace Business.Concretes
{
    public class ManagerManager:IManagerService
    {

        IManagerDal _managerDal;
        IMapper _mapper;
        ManagerBusinessRules _businessRules;

        public ManagerManager(ManagerBusinessRules businessRules, IManagerDal managerDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _managerDal = managerDal;
            _mapper = mapper;
        }

        public async Task<CreatedManagerResponse> Add(CreateManagerRequest createManagerRequest)
        {
            Manager manager = _mapper.Map<Manager>(createManagerRequest);
            Manager createdManager = await _managerDal.AddAsync(manager);
            CreatedManagerResponse createdManagerResponse = _mapper.Map<CreatedManagerResponse>(createdManager);
            return createdManagerResponse;
        }

        public async Task<DeletedManagerResponse> Delete(DeleteManagerRequest deleteManagerRequest)
        {
            var data = await _managerDal.GetAsync(i => i.Id == deleteManagerRequest.Id);
            _mapper.Map(deleteManagerRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _managerDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedManagerResponse>(result);
            return result2;
        }

        public async Task<CreatedManagerResponse> GetById(Guid id)
        {
            var result = await _managerDal.GetAsync(c => c.Id == id);
            Manager mappedManager = _mapper.Map<Manager>(result);

            CreatedManagerResponse createdManagerResponse = _mapper.Map<CreatedManagerResponse>(mappedManager);

            return createdManagerResponse;
        }


        public async Task<IPaginate<GetListManagerResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _managerDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );

            var result = _mapper.Map<Paginate<GetListManagerResponse>>(data);
            return result;
        }


        public async Task<UpdatedManagerResponse> Update(UpdateManagerRequest updateManagerRequest)
        {
            var data = await _managerDal.GetAsync(i => i.Id == updateManagerRequest.Id);
            _mapper.Map(updateManagerRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _managerDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedManagerResponse>(data);
            return result;
        }
    }
}

