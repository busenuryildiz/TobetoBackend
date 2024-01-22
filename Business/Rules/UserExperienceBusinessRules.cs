using Business.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Rules;

namespace Business.Rules
{
    public class UserExperienceBusinessRules:BaseBusinessRules
    {
        private readonly IUserExperienceDal _userExperienceDal;

        public UserExperienceBusinessRules(IUserExperienceDal userExperienceDal)
        {
            _userExperienceDal = userExperienceDal;
        }

        public async Task WorkBeginDateCannotBeGreaterThanWorkEndDate(DateTime workBeginDate, DateTime workEndDate)
        {
            if (workBeginDate > workEndDate)
            {
                throw new BusinessException(BusinessMessages.WorkBeginDateCannotBeGreaterThanWorkEndDate);
            }
        }
    }
}
