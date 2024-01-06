using Business.DTOs.Request.District;
using Business.DTOs.Response.District;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IDistrictService
    {
        Task<IPaginate<GetListDistrictResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedDistrictResponse> Add(CreateDistrictRequest createDistrictRequest);
        Task<UpdatedDistrictResponse> Update(UpdateDistrictRequest updateDistrictRequest);
        Task<DeletedDistrictResponse> Delete(DeleteDistrictRequest deleteDistrictRequest);
        Task<CreatedDistrictResponse> GetById(int id);
    }
}
