using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.BadgeOfUser;
using Business.DTOs.Response.BadgeOfUser;
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
    public class BadgeOfUserManager : IBadgeOfUserService
    {
        IBadgeOfUserDal _blogDal;
        IMapper _mapper;

        public BadgeOfUserManager(IBadgeOfUserDal blogDal, IMapper mapper)
        {
            _blogDal = blogDal;
            _mapper = mapper;
        }

        public async Task<CreatedBadgeOfUserResponse> Add(CreateBadgeOfUserRequest createBadgeOfUserRequest)
        {
            BadgeOfUser blog = _mapper.Map<BadgeOfUser>(createBadgeOfUserRequest);
            BadgeOfUser createdBadgeOfUser = await _blogDal.AddAsync(blog);
            CreatedBadgeOfUserResponse createdBadgeOfUserResponse = _mapper.Map<CreatedBadgeOfUserResponse>(createdBadgeOfUser);
            return createdBadgeOfUserResponse;
        }

        public async Task<DeletedBadgeOfUserResponse> Delete(DeleteBadgeOfUserRequest deleteBadgeOfUserRequest)
        {
            var data = await _blogDal.GetAsync(i => i.Id == deleteBadgeOfUserRequest.Id);
            _mapper.Map(deleteBadgeOfUserRequest, data);
            var result = await _blogDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedBadgeOfUserResponse>(result);
            return result2;
        }

        public async Task<CreatedBadgeOfUserResponse> GetById(int id)
        {
            var result = await _blogDal.GetAsync(c => c.Id == id);
            BadgeOfUser mappedBadgeOfUser = _mapper.Map<BadgeOfUser>(result);
            CreatedBadgeOfUserResponse createdBadgeOfUserResponse = _mapper.Map<CreatedBadgeOfUserResponse>(mappedBadgeOfUser);
            return createdBadgeOfUserResponse;
        }


        public async Task<IPaginate<GetListBadgeOfUserResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _blogDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListBadgeOfUserResponse>>(data);
            return result;
        }


        public async Task<UpdatedBadgeOfUserResponse> Update(UpdateBadgeOfUserRequest updateBadgeOfUserRequest)
        {
            var data = await _blogDal.GetAsync(i => i.Id == updateBadgeOfUserRequest.Id);
            _mapper.Map(updateBadgeOfUserRequest, data);
            await _blogDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedBadgeOfUserResponse>(data);
            return result;
        }
    }
}
