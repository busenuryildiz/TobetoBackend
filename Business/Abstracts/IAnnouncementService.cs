using Business.DTOs.Request.Announcement;
using Business.DTOs.Response.Announcement;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAnnouncementService
    {
        Task<IPaginate<GetListAnnouncementResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedAnnouncementResponse> Add(CreateAnnouncementRequest createAnnouncementRequest);
        Task<UpdatedAnnouncementResponse> Update(UpdateAnnouncementRequest updateAnnouncementRequest);
        Task<DeletedAnnouncementResponse> Delete(DeleteAnnouncementRequest deleteAnnouncementRequest);
        Task<CreatedAnnouncementResponse> GetById(int id);
    }
}
