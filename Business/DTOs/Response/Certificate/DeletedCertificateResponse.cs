using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Certificate
{
    public class DeletedCertificateResponse : BasePageableModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }// Kullanıcıya ait sertifika
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
