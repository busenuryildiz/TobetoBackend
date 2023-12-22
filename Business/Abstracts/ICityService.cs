using Business.DTOs.Request.City;
using Business.DTOs.Response.City;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICityService
    {
        Task<IPaginate<GetListCityResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCityResponse> Add(CreateCityRequest createCityRequest);
        Task<UpdatedCityResponse> Update(UpdateCityRequest updateCityRequest);
        Task<DeletedCityResponse> Delete(DeleteCityRequest deleteCityRequest);
        Task<CreatedCityResponse> GetById(int id);
    }
}
