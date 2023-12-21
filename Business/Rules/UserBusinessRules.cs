using Business.Messages;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
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

        public async Task NationalIdNumberCannotBeTheSame(string nationalIdentity)
        {
            if (nationalIdentity.Length != 11)
            {
                throw new BusinessException(BusinessMessages.NationalIdNumberCannotBeTheSame);
            }

            var usersWithSameNationalId = await _userDal.GetListAsync(
                predicate: p => p.NationalIdentity == nationalIdentity
            );

            // Ulusal kimlik numarasının uzunluğunu kontrol ettikten sonra aynı numaraya sahip kullanıcıları kontrol ediyoruz
            if (usersWithSameNationalId.Count > 0)
            {
                throw new BusinessException(BusinessMessages.NationalIdNumberCannotBeTheSame);
            }
        }



    }
}
