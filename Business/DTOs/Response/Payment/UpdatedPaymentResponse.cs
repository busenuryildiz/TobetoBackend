using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Payment
{
    public class UpdatedPaymentResponse:BasePageableModel
    {
        public int Id { get; set; }
        public int StudentCourseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool? Status { get; set; }
    }
}
