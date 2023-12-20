using Business.DTOs.Request.Payment;
using Business.DTOs.Response.Payment;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IPaymentService
    {
        Task<IPaginate<GetListPaymentResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedPaymentResponse> Add(CreatePaymentRequest createPaymentRequest);
        Task<UpdatedPaymentResponse> Update(UpdatePaymentRequest updatePaymentRequest);
        Task<DeletedPaymentResponse> Delete(DeletePaymentRequest deletePaymentRequest);
        Task<CreatedPaymentResponse> GetById(int id);
    }
}
