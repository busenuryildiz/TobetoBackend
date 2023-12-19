using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class BusinessMessages
    {
        public static string CategoryLimit = "Kategori sayısı max 10 olabilir";
        public static string ProductLimitInCategory = "Bir kategoride max 20 ürün olabilir";
        public static string CustomerLimitInCity = "Bir şehirde max 10 müşteri olabilir";
        public static string ContactNameCantRepeat = "ContactName aynı olamaz";
    }
}
