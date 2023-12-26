using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Assignments;
using Business.DTOs.Request.EducationInformation;
using Business.DTOs.Response.EducationInformation;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class EducationInformationManager: IEducationInformationService
    {

        IEducationInformationDal _educationInformationDal;
        IMapper _mapper;
        EducationInformationBusinessRules _educationInformationBusinessRules;
        public EducationInformationManager(IEducationInformationDal educationInformationDal, IMapper mapper, EducationInformationBusinessRules educationInformationBusinessRules)
        {
            _educationInformationDal = educationInformationDal;
            _mapper = mapper;
            _educationInformationBusinessRules = educationInformationBusinessRules;
        }

        public async Task<CreatedEducationInformationResponse> Add(CreateEducationInformationRequest createEducationInformationRequest)
        {
            DateTime BeginningYear = createEducationInformationRequest.BeginningYear;
            DateTime graduationYear = createEducationInformationRequest.GraduationYear;

            await _educationInformationBusinessRules.TheBeginnerYearCannotBeGreaterThanTheGraduationYear(BeginningYear, graduationYear);

            EducationInformation educationInformation = _mapper.Map<EducationInformation>(createEducationInformationRequest);
            EducationInformation createdEducationInformation = await _educationInformationDal.AddAsync(educationInformation);
            CreatedEducationInformationResponse createdEducationInformationResponse = _mapper.Map<CreatedEducationInformationResponse>(createdEducationInformation);
            return createdEducationInformationResponse;
        }

        public async Task<DeletedEducationInformationResponse> Delete(DeleteEducationInformationRequest deleteEducationInformationRequest)
        {

            var data = await _educationInformationDal.GetAsync(i => i.Id == deleteEducationInformationRequest.Id);
            _mapper.Map(deleteEducationInformationRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _educationInformationDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedEducationInformationResponse>(result);
            return result2;
        }

        public async Task<CreatedEducationInformationResponse> GetById(int id)
        {
            var result = await _educationInformationDal.GetAsync(c => c.Id == id);
            EducationInformation mappedEducationInformation = _mapper.Map<EducationInformation>(result);

            CreatedEducationInformationResponse createdEducationInformationResponse = _mapper.Map<CreatedEducationInformationResponse>(mappedEducationInformation);

            return createdEducationInformationResponse;
        }


        public async Task<IPaginate<GetListEducationInformationResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _educationInformationDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListEducationInformationResponse>>(data);
            return result;
        }


        public async Task<UpdatedEducationInformationResponse> Update(UpdateEducationInformationRequest updateEducationInformationRequest)
        {

            var data = await _educationInformationDal.GetAsync(i => i.Id == updateEducationInformationRequest.Id);
            _mapper.Map(updateEducationInformationRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _educationInformationDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedEducationInformationResponse>(data);
            return result;
        }
    }
}
