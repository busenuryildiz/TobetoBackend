using AutoMapper;
using Business.DTOs.Request.ApplicationStudent;
using Business.DTOs.Response.ApplicationStudent;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;

namespace Business.Concretes
{
    public class ApplicationStudentManager: IApplicationStudentService
    {

        IApplicationStudentDal _applicationStudentDal;
        IMapper _mapper;

        public ApplicationStudentManager(IApplicationStudentDal applicationStudentDal, IMapper mapper)
        {
            _applicationStudentDal = applicationStudentDal;
            _mapper = mapper;
        }

        public async Task<CreatedApplicationStudentResponse> Add(CreateApplicationStudentRequest createApplicationStudentRequest)
        {
            ApplicationStudent applicationStudent = _mapper.Map<ApplicationStudent>(createApplicationStudentRequest);
            ApplicationStudent createdApplicationStudent = await _applicationStudentDal.AddAsync(applicationStudent);
            CreatedApplicationStudentResponse createdApplicationStudentResponse = _mapper.Map<CreatedApplicationStudentResponse>(createdApplicationStudent);
            return createdApplicationStudentResponse;
        }

        public async Task<DeletedApplicationStudentResponse> Delete(DeleteApplicationStudentRequest deleteApplicationStudentRequest)
        {
            var data = await _applicationStudentDal.GetAsync(i => i.Id == deleteApplicationStudentRequest.Id);
            _mapper.Map(deleteApplicationStudentRequest, data);
            var result = await _applicationStudentDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedApplicationStudentResponse>(result);
            return result2;
        }

        public async Task<CreatedApplicationStudentResponse> GetById(int id)
        {
            var result = await _applicationStudentDal.GetAsync(c => c.Id == id);
            ApplicationStudent mappedApplicationStudent = _mapper.Map<ApplicationStudent>(result);
            CreatedApplicationStudentResponse createdApplicationStudentResponse = _mapper.Map<CreatedApplicationStudentResponse>(mappedApplicationStudent);
            return createdApplicationStudentResponse;
        }


        public async Task<IPaginate<GetListApplicationStudentResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _applicationStudentDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListApplicationStudentResponse>>(data);
            return result;
        }


        public async Task<UpdatedApplicationStudentResponse> Update(UpdateApplicationStudentRequest updateApplicationStudentRequest)
        {
            var data = await _applicationStudentDal.GetAsync(i => i.Id == updateApplicationStudentRequest.Id);
            _mapper.Map(updateApplicationStudentRequest, data);
            await _applicationStudentDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedApplicationStudentResponse>(data);
            return result;
        }
    
}
}
