using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.ContactUs;
using Business.DTOs.Response.ContactUs;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{

    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _ContactUsDal;
        IMapper _mapper;
        ContactUsBusinessRules _businessRules;

        public ContactUsManager(ContactUsBusinessRules businessRules, IContactUsDal ContactUsDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _ContactUsDal = ContactUsDal;
            _mapper = mapper;
        }

        public async Task<CreatedContactUsResponse> Add(CreateContactUsRequest createContactUsRequest)
        {
            ContactUs ContactUs = _mapper.Map<ContactUs>(createContactUsRequest);
            ContactUs createdContactUs = await _ContactUsDal.AddAsync(ContactUs);
            CreatedContactUsResponse createdContactUsResponse = _mapper.Map<CreatedContactUsResponse>(createdContactUs);
            return createdContactUsResponse;
        }

        public async Task<DeletedContactUsResponse> Delete(DeleteContactUsRequest deleteContactUsRequest)
        {
            var data = await _ContactUsDal.GetAsync(i => i.Id == deleteContactUsRequest.Id);
            _mapper.Map(deleteContactUsRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _ContactUsDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedContactUsResponse>(result);
            return result2;
        }

        public async Task<CreatedContactUsResponse> GetById(int id)
        {
            var result = await _ContactUsDal.GetAsync(c => c.Id == id);
            ContactUs mappedContactUs = _mapper.Map<ContactUs>(result);

            CreatedContactUsResponse createdContactUsResponse = _mapper.Map<CreatedContactUsResponse>(mappedContactUs);

            return createdContactUsResponse;
        }


        public async Task<IPaginate<GetListContactUsResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _ContactUsDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListContactUsResponse>>(data);
            return result;
        }


        public async Task<UpdatedContactUsResponse> Update(UpdateContactUsRequest updateContactUsRequest)
        {
            var data = await _ContactUsDal.GetAsync(i => i.Id == updateContactUsRequest.Id);
            _mapper.Map(updateContactUsRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _ContactUsDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedContactUsResponse>(data);
            return result;
        }
    }
}

