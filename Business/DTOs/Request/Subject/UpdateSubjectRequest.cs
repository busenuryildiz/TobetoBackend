using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Subject
{
    public class UpdateSubjectRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Diğer gerekli özellikleri ekleyin
    }
}
