using Business.DTOs.Request.Country;
using Business.DTOs.Response.Country;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICountryService
    {
        Task<IPaginate<GetListCountryResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCountryResponse> Add(CreateCountryRequest createCountryRequest);
        Task<UpdatedCountryResponse> Update(UpdateCountryRequest updateCountryRequest);
        Task<DeletedCountryResponse> Delete(DeleteCountryRequest deleteCountryRequest);
        Task<CreatedCountryResponse> GetById(int id);
    }
}
