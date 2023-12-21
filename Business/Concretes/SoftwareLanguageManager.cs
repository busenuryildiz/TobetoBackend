using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.SoftwareLanguage;
using Business.DTOs.Response.SoftwareLanguage;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SoftwareLanguageManager : ISoftwareLanguageService
    {
        ISoftwareLanguageDal _SoftwareLanguageDal;
        IMapper _mapper;
        SoftwareLanguageBusinessRules _businessRules;

        public SoftwareLanguageManager(SoftwareLanguageBusinessRules businessRules, ISoftwareLanguageDal SoftwareLanguageDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _SoftwareLanguageDal = SoftwareLanguageDal;
            _mapper = mapper;
        }

        public async Task<CreatedSoftwareLanguageResponse> Add(CreateSoftwareLanguageRequest createSoftwareLanguageRequest)
        {
            SoftwareLanguage SoftwareLanguage = _mapper.Map<SoftwareLanguage>(createSoftwareLanguageRequest);
            SoftwareLanguage createdSoftwareLanguage = await _SoftwareLanguageDal.AddAsync(SoftwareLanguage);
            CreatedSoftwareLanguageResponse createdSoftwareLanguageResponse = _mapper.Map<CreatedSoftwareLanguageResponse>(createdSoftwareLanguage);
            return createdSoftwareLanguageResponse;
        }

        public async Task<DeletedSoftwareLanguageResponse> Delete(DeleteSoftwareLanguageRequest deleteSoftwareLanguageRequest)
        {
            var data = await _SoftwareLanguageDal.GetAsync(i => i.Id == deleteSoftwareLanguageRequest.Id);
            _mapper.Map(deleteSoftwareLanguageRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _SoftwareLanguageDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedSoftwareLanguageResponse>(result);
            return result2;
        }

        public async Task<CreatedSoftwareLanguageResponse> GetById(int id)
        {
            var result = await _SoftwareLanguageDal.GetAsync(c => c.Id == id);
            SoftwareLanguage mappedSoftwareLanguage = _mapper.Map<SoftwareLanguage>(result);

            CreatedSoftwareLanguageResponse createdSoftwareLanguageResponse = _mapper.Map<CreatedSoftwareLanguageResponse>(mappedSoftwareLanguage);

            return createdSoftwareLanguageResponse;
        }


        public async Task<IPaginate<GetListSoftwareLanguageResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _SoftwareLanguageDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListSoftwareLanguageResponse>>(data);
            return result;
        }


        public async Task<UpdatedSoftwareLanguageResponse> Update(UpdateSoftwareLanguageRequest updateSoftwareLanguageRequest)
        {
            var data = await _SoftwareLanguageDal.GetAsync(i => i.Id == updateSoftwareLanguageRequest.Id);
            _mapper.Map(updateSoftwareLanguageRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _SoftwareLanguageDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedSoftwareLanguageResponse>(data);
            return result;
        }
    }

    public interface ISoftwareLanguageService
    {
    }
}

