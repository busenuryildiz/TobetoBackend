using Core.Business.Rules;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UserBusinessRules:BaseBusinessRules
    {
        private readonly IUserDal _userDal;
        public UserBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;      
        }
    }
}
