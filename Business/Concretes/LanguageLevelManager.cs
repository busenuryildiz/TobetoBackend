using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.LanguageLevel;
using Business.DTOs.Response.LanguageLevel;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
        public class LanguageLevelManager : ILanguageLevelService
        {
            ILanguageLevelDal _languageLevelDal;
            IMapper _mapper;
            LanguageLevelBusinessRules _businessRules;

            public LanguageLevelManager(LanguageLevelBusinessRules businessRules, ILanguageLevelDal languageLevelDal, IMapper mapper)
            {
                _businessRules = businessRules;
                _languageLevelDal = languageLevelDal;
                _mapper = mapper;
            }

            public async Task<CreatedLanguageLevelResponse> Add(CreateLanguageLevelRequest createLanguageLevelRequest)
            {
                LanguageLevel languageLevel = _mapper.Map<LanguageLevel>(createLanguageLevelRequest);
                LanguageLevel createdLanguageLevel = await _languageLevelDal.AddAsync(languageLevel);
                CreatedLanguageLevelResponse createdLanguageLevelResponse = _mapper.Map<CreatedLanguageLevelResponse>(createdLanguageLevel);
                return createdLanguageLevelResponse;
            }

            public async Task<DeletedLanguageLevelResponse> Delete(DeleteLanguageLevelRequest deleteLanguageLevelRequest)
            {
                var data = await _languageLevelDal.GetAsync(predicate: i => i.Id == deleteLanguageLevelRequest.Id);
                _mapper.Map(deleteLanguageLevelRequest, data);
                var result = await _languageLevelDal.DeleteAsync(data);
                var result2 = _mapper.Map<DeletedLanguageLevelResponse>(result);
                return result2;
            }

            public async Task<CreatedLanguageLevelResponse> GetById(int id)
            {
                var result = await _languageLevelDal.GetAsync(c => c.Id == id);
                LanguageLevel mappedLanguageLevel = _mapper.Map<LanguageLevel>(result);

                CreatedLanguageLevelResponse createdLanguageLevelResponse = _mapper.Map<CreatedLanguageLevelResponse>(mappedLanguageLevel);

                return createdLanguageLevelResponse;
            }


            public async Task<IPaginate<GetListLanguageLevelResponse>> GetListAsync(PageRequest pageRequest)
            {
                var data = await _languageLevelDal.GetListAsync(
                    index: pageRequest.PageIndex,
                    size: pageRequest.PageSize
                );
                var result = _mapper.Map<Paginate<GetListLanguageLevelResponse>>(data);
                return result;
            }


            public async Task<UpdatedLanguageLevelResponse> Update(UpdateLanguageLevelRequest updateLanguageLevelRequest)
            {
                var data = await _languageLevelDal.GetAsync(i => i.Id == updateLanguageLevelRequest.Id);
                _mapper.Map(updateLanguageLevelRequest, data);
                data.UpdatedDate = DateTime.Now;
                await _languageLevelDal.UpdateAsync(data);
                var result = _mapper.Map<UpdatedLanguageLevelResponse>(data);
                return result;
            }
        }
}
