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
    public class ExamBusinessRules : BaseBusinessRules
    {
        IExamDal _examDal;
        public ExamBusinessRules(IExamDal examDal)
        {
            _examDal = examDal;
        }

        //public async Task ValidateExamPoint(int examPoint)
        //{
        //    if (examPoint < 0 || examPoint > 100)
        //    {
        //        throw new BusinessException(BusinessMessages.ValidateExamPoint);
        //    }
        //}
    }
}
