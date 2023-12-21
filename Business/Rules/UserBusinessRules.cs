using Core.Business.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Business.Rules
{
    public class UserBusinessRules:BaseBusinessRules
    {
        private readonly IUserDal _userDal;

        public UserBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task EmailShouldBeUnique(string email)
        {
            var existingUsers = await _userDal.GetListAsync(predicate: p => p.Email == email);

            if (existingUsers != null && existingUsers.Count > 0)
            {
                throw new BusinessException(BusinessMessages.EmailShouldBeUnique);
            }
        }
        public async Task PhoneShouldBeUnique(string phone)
        {
            var existingUsers = await _userDal.GetListAsync(predicate: p => p.PhoneNumber == phone);

            if (existingUsers != null)
            {
                throw new BusinessException(BusinessMessages.PhoneShouldBeUnique);
            }
        }




    }
}
