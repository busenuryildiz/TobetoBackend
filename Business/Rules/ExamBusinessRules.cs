using Core.Business.Rules;
using DataAccess.Abstract;
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
    }
}
