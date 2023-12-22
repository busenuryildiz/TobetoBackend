using Business.DTOs.Request.County;
using Business.DTOs.Response.County;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
        public interface ICountyService
        {
            Task<IPaginate<GetListCountyResponse>> GetListAsync(PageRequest pageRequest);
            Task<CreatedCountyResponse> Add(CreateCountyRequest createCountyRequest);
            Task<UpdatedCountyResponse> Update(UpdateCountyRequest updateCountyRequest);
            Task<DeletedCountyResponse> Delete(DeleteCountyRequest deleteCountyRequest);
            Task<CreatedCountyResponse> GetById(int id);
        }
    
}
