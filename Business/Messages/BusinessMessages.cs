using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class BusinessMessages
    {
        public static string NationalIdNumberCannotBeTheSame = "National Identity'niz başka bir kullanıcı ile aynı olamaz veya National identity number must be 11 digits. ";
        public static string NationalIdNumberCannotBeTheSame2 = "National identity number must be 11 digits.";
        public static string CustomerLimitInCity = "Bir şehirde max 10 müşteri olabilir";
        public static string ContactNameCantRepeat = "ContactName aynı olamaz";
    }
}
