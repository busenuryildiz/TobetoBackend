using Business.DTOs.Request.Certificate;
using Business.DTOs.Response.Certificate;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICertificateService
    {
        Task<IPaginate<GetListCertificateResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCertificateResponse> Add(CreateCertificateRequest createCertificateRequest);
        Task<UpdatedCertificateResponse> Update(UpdateCertificateRequest updateCertificateRequest);
        Task<DeletedCertificateResponse> Delete(DeleteCertificateRequest deleteCertificateRequest);
        Task<CreatedCertificateResponse> GetById(int id);
    }
}
