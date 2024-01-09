using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Application;
using Business.DTOs.Response.Application;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ApplicationManager:IApplicationService
    {
        IApplicationDal _applicationDal;
        IMapper _mapper;
        ApplicationBusinessRules _businessRules;

        public ApplicationManager(ApplicationBusinessRules businessRules, IApplicationDal applicationDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _applicationDal = applicationDal;
            _mapper = mapper;
        }

        public async Task<CreatedApplicationResponse> Add(CreateApplicationRequest createApplicationRequest)
        {
            Application application = _mapper.Map<Application>(createApplicationRequest);
            Application createdApplication = await _applicationDal.AddAsync(application);
            CreatedApplicationResponse createdApplicationResponse = _mapper.Map<CreatedApplicationResponse>(createdApplication);
            return createdApplicationResponse;
        }

        public async Task<DeletedApplicationResponse> Delete(DeleteApplicationRequest deleteApplicationRequest)
        {
            var data = await _applicationDal.GetAsync(i => i.Id == deleteApplicationRequest.Id);
            _mapper.Map(deleteApplicationRequest, data);
            var result = await _applicationDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedApplicationResponse>(result);
            return result2;
        }

        public async Task<CreatedApplicationResponse> GetById(int id)
        {
            var result = await _applicationDal.GetAsync(c => c.Id == id);
            Application mappedApplication = _mapper.Map<Application>(result);
            CreatedApplicationResponse createdApplicationResponse = _mapper.Map<CreatedApplicationResponse>(mappedApplication);
            return createdApplicationResponse;
        }


        public async Task<IPaginate<GetListApplicationResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _applicationDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListApplicationResponse>>(data);
            return result;
        }


        public async Task<UpdatedApplicationResponse> Update(UpdateApplicationRequest updateApplicationRequest)
        {
            var data = await _applicationDal.GetAsync(i => i.Id == updateApplicationRequest.Id);
            _mapper.Map(updateApplicationRequest, data);
            await _applicationDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedApplicationResponse>(data);
            return result;
        }
    }
}

