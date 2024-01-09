using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.MediaPost;
using Business.DTOs.Response.MediaPost;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class MediaPostManager:IMediaPostService
    {
        IMediaPostDal _mediaPostDal;
        IMapper _mapper;
        MediaPostBusinessRules _businessRules;

        public MediaPostManager(MediaPostBusinessRules businessRules, IMediaPostDal mediaPostDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _mediaPostDal = mediaPostDal;
            _mapper = mapper;
        }

        public async Task<CreatedMediaPostResponse> Add(CreateMediaPostRequest createMediaPostRequest)
        {
            MediaPost mediaPost = _mapper.Map<MediaPost>(createMediaPostRequest);
            MediaPost createdMediaPost = await _mediaPostDal.AddAsync(mediaPost);
            CreatedMediaPostResponse createdMediaPostResponse = _mapper.Map<CreatedMediaPostResponse>(createdMediaPost);
            return createdMediaPostResponse;
        }

        public async Task<DeletedMediaPostResponse> Delete(DeleteMediaPostRequest deleteMediaPostRequest)
        {
            var data = await _mediaPostDal.GetAsync(i => i.Id == deleteMediaPostRequest.Id);
            _mapper.Map(deleteMediaPostRequest, data);
            var result = await _mediaPostDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedMediaPostResponse>(result);
            return result2;
        }

        public async Task<CreatedMediaPostResponse> GetById(int id)
        {
            var result = await _mediaPostDal.GetAsync(c => c.Id == id);
            MediaPost mappedMediaPost = _mapper.Map<MediaPost>(result);
            CreatedMediaPostResponse createdMediaPostResponse = _mapper.Map<CreatedMediaPostResponse>(mappedMediaPost);
            return createdMediaPostResponse;
        }

        public async Task<IPaginate<GetListMediaPostResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _mediaPostDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListMediaPostResponse>>(data);
            return result;
        }

        public async Task<UpdatedMediaPostResponse> Update(UpdateMediaPostRequest updateMediaPostRequest)
        {
            var data = await _mediaPostDal.GetAsync(i => i.Id == updateMediaPostRequest.Id);
            _mapper.Map(updateMediaPostRequest, data);
            await _mediaPostDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedMediaPostResponse>(data);
            return result;
        }
    }
}

