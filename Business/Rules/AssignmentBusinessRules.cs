using Business.Messages;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class AssignmentBusinessRules: BaseBusinessRules
    {
        private readonly IAssignmentDal _assignmentDal;

        public AssignmentBusinessRules(IAssignmentDal assignmentDal)
        {
            _assignmentDal = assignmentDal;
        }


        //public async Task DoNotSendItAfterTheAssignmentPeriodIsOver(DateTime deadLine)
        //{
        //    if (DateTime.Now > deadLine)
        //    {
        //        throw new BusinessException(BusinessMessages.DoNotSendItAfterTheAssignmentPeriodIsOver);
        //    }
        //}

    }
}
