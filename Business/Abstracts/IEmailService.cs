using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEmailService
    {
        void SendEmail(string fromEmail, string fullName,string subject, string body);
        void ForgetPassword(string toEmail);

    }
}
