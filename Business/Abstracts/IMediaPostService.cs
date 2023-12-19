using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.MediaPost;
using Business.DTOs.Response.MediaPost;

namespace Business.Abstracts
{
    public interface IMediaPostService
    {
        Task<IPaginate<GetListMediaPostResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedMediaPostResponse> Add(CreateMediaPostRequest createMediaPostRequest);
        Task<UpdatedMediaPostResponse> Update(UpdateMediaPostRequest updateMediaPostRequest);
        Task<DeletedMediaPostResponse> Delete(DeleteMediaPostRequest deleteMediaPostRequest);
        Task<CreatedMediaPostResponse> GetById(int id);
    }
}
