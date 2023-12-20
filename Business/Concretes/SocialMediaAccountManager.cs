using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.SocialMediaAccount;
using Business.DTOs.Response.SocialMediaAccount;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class SocialMediaAccountManager:ISocialMediaAccountService
    {
        ISocialMediaAccountDal _socialMediaAccountDal;
        IMapper _mapper;
        SocialMediaAccountBusinessRules _businessRules;

        public SocialMediaAccountManager(SocialMediaAccountBusinessRules businessRules, ISocialMediaAccountDal socialMediaAccountDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _socialMediaAccountDal = socialMediaAccountDal;
            _mapper = mapper;
        }

        public async Task<CreatedSocialMediaAccountResponse> Add(CreateSocialMediaAccountRequest createSocialMediaAccountRequest)
        {
            SocialMediaAccount socialMediaAccount = _mapper.Map<SocialMediaAccount>(createSocialMediaAccountRequest);
            SocialMediaAccount createdSocialMediaAccount = await _socialMediaAccountDal.AddAsync(socialMediaAccount);
            CreatedSocialMediaAccountResponse createdSocialMediaAccountResponse = _mapper.Map<CreatedSocialMediaAccountResponse>(createdSocialMediaAccount);
            return createdSocialMediaAccountResponse;
        }

        public async Task<DeletedSocialMediaAccountResponse> Delete(DeleteSocialMediaAccountRequest deleteSocialMediaAccountRequest)
        {
            var data = await _socialMediaAccountDal.GetAsync(i => i.Id == deleteSocialMediaAccountRequest.Id);
            _mapper.Map(deleteSocialMediaAccountRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _socialMediaAccountDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedSocialMediaAccountResponse>(result);
            return result2;
        }

        public async Task<CreatedSocialMediaAccountResponse> GetById(int id)
        {
            var result = await _socialMediaAccountDal.GetAsync(c => c.Id == id);
            SocialMediaAccount mappedSocialMediaAccount = _mapper.Map<SocialMediaAccount>(result);

            CreatedSocialMediaAccountResponse createdSocialMediaAccountResponse = _mapper.Map<CreatedSocialMediaAccountResponse>(mappedSocialMediaAccount);

            return createdSocialMediaAccountResponse;
        }


        public async Task<IPaginate<GetListSocialMediaAccountResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _socialMediaAccountDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListSocialMediaAccountResponse>>(data);
            return result;
        }


        public async Task<UpdatedSocialMediaAccountResponse> Update(UpdateSocialMediaAccountRequest updateSocialMediaAccountRequest)
        {
            var data = await _socialMediaAccountDal.GetAsync(i => i.Id == updateSocialMediaAccountRequest.Id);
            _mapper.Map(updateSocialMediaAccountRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _socialMediaAccountDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedSocialMediaAccountResponse>(data);
            return result;
        }
    }
}

