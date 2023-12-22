using Business.DTOs.Request.ContactUs;
using Business.DTOs.Response.ContactUs;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IContactUsService
    {
        Task<IPaginate<GetListContactUsResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedContactUsResponse> Add(CreateContactUsRequest createContactUsRequest);
        Task<UpdatedContactUsResponse> Update(UpdateContactUsRequest updateContactUsRequest);
        Task<DeletedContactUsResponse> Delete(DeleteContactUsRequest deleteContactUsRequest);
        Task<CreatedContactUsResponse> GetById(int id);
    }
}
