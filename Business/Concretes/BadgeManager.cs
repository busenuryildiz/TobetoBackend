using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Badge;
using Business.DTOs.Response.Badge;
using Business.Rules.BusinessRules;
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
    public class BadgeManager : IBadgeService
    {
        IBadgeDal _blogDal;
        IMapper _mapper;

        public BadgeManager(IBadgeDal blogDal, IMapper mapper)
        {
            _blogDal = blogDal;
            _mapper = mapper;
        }

        public async Task<CreatedBadgeResponse> Add(CreateBadgeRequest createBadgeRequest)
        {
            Badge blog = _mapper.Map<Badge>(createBadgeRequest);
            Badge createdBadge = await _blogDal.AddAsync(blog);
            CreatedBadgeResponse createdBadgeResponse = _mapper.Map<CreatedBadgeResponse>(createdBadge);
            return createdBadgeResponse;
        }

        public async Task<DeletedBadgeResponse> Delete(DeleteBadgeRequest deleteBadgeRequest)
        {
            var data = await _blogDal.GetAsync(i => i.Id == deleteBadgeRequest.Id);
            _mapper.Map(deleteBadgeRequest, data);
            var result = await _blogDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedBadgeResponse>(result);
            return result2;
        }

        public async Task<CreatedBadgeResponse> GetById(int id)
        {
            var result = await _blogDal.GetAsync(c => c.Id == id);
            Badge mappedBadge = _mapper.Map<Badge>(result);
            CreatedBadgeResponse createdBadgeResponse = _mapper.Map<CreatedBadgeResponse>(mappedBadge);
            return createdBadgeResponse;
        }


        public async Task<IPaginate<GetListBadgeResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _blogDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListBadgeResponse>>(data);
            return result;
        }


        public async Task<UpdatedBadgeResponse> Update(UpdateBadgeRequest updateBadgeRequest)
        {
            var data = await _blogDal.GetAsync(i => i.Id == updateBadgeRequest.Id);
            _mapper.Map(updateBadgeRequest, data);
            await _blogDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedBadgeResponse>(data);
            return result;
        }
    }
}
