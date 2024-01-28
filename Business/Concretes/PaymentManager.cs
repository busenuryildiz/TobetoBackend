using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Payment;
using Business.DTOs.Response.Payment;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class PaymentManager:IPaymentService
    {
        IPaymentDal _paymentDal;
        IMapper _mapper;
        PaymentBusinessRules _businessRules;

        public PaymentManager(PaymentBusinessRules businessRules, IPaymentDal paymentDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _paymentDal = paymentDal;
            _mapper = mapper;
        }

        public async Task<CreatedPaymentResponse> Add(CreatePaymentRequest createPaymentRequest)
        {
            Payment payment = _mapper.Map<Payment>(createPaymentRequest);
            Payment createdPayment = await _paymentDal.AddAsync(payment);
            CreatedPaymentResponse createdPaymentResponse = _mapper.Map<CreatedPaymentResponse>(createdPayment);
            
            return createdPaymentResponse;
        }

        public async Task<DeletedPaymentResponse> Delete(DeletePaymentRequest deletePaymentRequest)
        {
            var data = await _paymentDal.GetAsync(i => i.Id == deletePaymentRequest.Id);
            _mapper.Map(deletePaymentRequest, data);
            var result = await _paymentDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedPaymentResponse>(result);
            return result2;
        }

        public async Task<CreatedPaymentResponse> GetById(int id)
        {
            var result = await _paymentDal.GetAsync(c => c.Id == id);
            Payment mappedPayment = _mapper.Map<Payment>(result);
            CreatedPaymentResponse createdPaymentResponse = _mapper.Map<CreatedPaymentResponse>(mappedPayment);
            return createdPaymentResponse;
        }


        public async Task<IPaginate<GetListPaymentResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _paymentDal.GetListAsync(
                include: u => u
                    .Include(u => u.StudentCourse),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );

            var result = _mapper.Map<Paginate<GetListPaymentResponse>>(data);
            return result;
        }


        public async Task<UpdatedPaymentResponse> Update(UpdatePaymentRequest updatePaymentRequest)
        {
            var data = await _paymentDal.GetAsync(i => i.Id == updatePaymentRequest.Id);
            _mapper.Map(updatePaymentRequest, data);
            await _paymentDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedPaymentResponse>(data);
            return result;
        }
    }
}
