using Business.DTOs.Request.Address;
using Business.DTOs.Response.Address;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAddressService
    {
        Task<IPaginate<GetListAddressResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedAddressResponse> Add(CreateAddressRequest createAddressRequest);
        Task<UpdatedAddressResponse> Update(UpdateAddressRequest updateAddressRequest);
        Task<DeletedAddressResponse> Delete(DeleteAddressRequest deleteAddressRequest);
        Task<CreatedAddressResponse> GetById(int id);
    }
}
