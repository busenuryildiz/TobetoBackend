using Business.Messages;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class EducationInformationBusinessRules : BaseBusinessRules
    {
        private readonly IEducationInformationDal _educationInformationDal;

        public EducationInformationBusinessRules(IEducationInformationDal educationInformationDal)
        {
            _educationInformationDal = educationInformationDal;
        }

        public async Task TheBeginnerYearCannotBeGreaterThanTheGraduationYear(DateTime beginnerYear, DateTime graduationYear)
        {
            if (beginnerYear > graduationYear)
            {
                throw new BusinessException(BusinessMessages.TheBeginnerYearCannotBeGreaterThanTheGraduationYear);
            }
        }
    }
}
