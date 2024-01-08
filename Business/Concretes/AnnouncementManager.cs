using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Announcement;
using Business.DTOs.Response.Announcement;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class AnnouncementManager:IAnnouncementService
    {
        IAnnouncementDal _announcementDal;
        IMapper _mapper;
        AnnouncementBusinessRules _businessRules;

        public AnnouncementManager(AnnouncementBusinessRules businessRules, IAnnouncementDal announcementDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _announcementDal = announcementDal;
            _mapper = mapper;
        }

        public async Task<CreatedAnnouncementResponse> Add(CreateAnnouncementRequest createAnnouncementRequest)
        {
            Announcement announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
            Announcement createdAnnouncement = await _announcementDal.AddAsync(announcement);
            CreatedAnnouncementResponse createdAnnouncementResponse = _mapper.Map<CreatedAnnouncementResponse>(createdAnnouncement);
            return createdAnnouncementResponse;
        }

        public async Task<DeletedAnnouncementResponse> Delete(DeleteAnnouncementRequest deleteAnnouncementRequest)
        {
            var data = await _announcementDal.GetAsync(i => i.Id == deleteAnnouncementRequest.Id);
            _mapper.Map(deleteAnnouncementRequest, data);
            var result = await _announcementDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedAnnouncementResponse>(result);
            return result2;
        }

        public async Task<CreatedAnnouncementResponse> GetById(int id)
        {
            var result = await _announcementDal.GetAsync(c => c.Id == id);
            Announcement mappedAnnouncement = _mapper.Map<Announcement>(result);

            CreatedAnnouncementResponse createdAnnouncementResponse = _mapper.Map<CreatedAnnouncementResponse>(mappedAnnouncement);

            return createdAnnouncementResponse;
        }

        public async Task<IPaginate<GetListAnnouncementResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _announcementDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListAnnouncementResponse>>(data);
            return result;
        }

        public async Task<UpdatedAnnouncementResponse> Update(UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            var data = await _announcementDal.GetAsync(i => i.Id == updateAnnouncementRequest.Id);
            _mapper.Map(updateAnnouncementRequest, data);
            await _announcementDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedAnnouncementResponse>(data);
            return result;
        }
    }
}
