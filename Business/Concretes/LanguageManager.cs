using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Language;
using Business.DTOs.Response.Language;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class LanguageManager : ILanguageService
    {
        ILanguageDal _languageDal;
        IMapper _mapper;
        LanguageBusinessRules _businessRules;

        public LanguageManager(LanguageBusinessRules businessRules, ILanguageDal languageDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _languageDal = languageDal;
            _mapper = mapper;
        }

        public async Task<CreatedLanguageResponse> Add(CreateLanguageRequest createLanguageRequest)
        {
            Language language = _mapper.Map<Language>(createLanguageRequest);
            Language createdLanguage = await _languageDal.AddAsync(language);
            CreatedLanguageResponse createdLanguageResponse = _mapper.Map<CreatedLanguageResponse>(createdLanguage);
            return createdLanguageResponse;
        }

        public async Task<DeletedLanguageResponse> Delete(DeleteLanguageRequest deleteLanguageRequest)
        {
            var data = await _languageDal.GetAsync(predicate: i => i.Id == deleteLanguageRequest.Id);
            _mapper.Map(deleteLanguageRequest, data);
            var result = await _languageDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedLanguageResponse>(result);
            return result2;
        }

        public async Task<CreatedLanguageResponse> GetById(int id)
        {
            var result = await _languageDal.GetAsync(c => c.Id == id);
            Language mappedLanguage = _mapper.Map<Language>(result);
            CreatedLanguageResponse createdLanguageResponse = _mapper.Map<CreatedLanguageResponse>(mappedLanguage);
            return createdLanguageResponse;
        }


        public async Task<IPaginate<GetListLanguageResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _languageDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListLanguageResponse>>(data);
            return result;
        }


        public async Task<UpdatedLanguageResponse> Update(UpdateLanguageRequest updateLanguageRequest)
        {
            var data = await _languageDal.GetAsync(i => i.Id == updateLanguageRequest.Id);
            _mapper.Map(updateLanguageRequest, data);
            await _languageDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedLanguageResponse>(data);
            return result;
        }
    }
}
