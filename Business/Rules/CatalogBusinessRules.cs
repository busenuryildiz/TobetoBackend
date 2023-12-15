using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class CatalogBusinessRules
    {
        ICatalogDal _catalogDal;

        public CatalogBusinessRules(ICatalogDal catalogDal)
        {
            _catalogDal = catalogDal;
        }
    }
}
