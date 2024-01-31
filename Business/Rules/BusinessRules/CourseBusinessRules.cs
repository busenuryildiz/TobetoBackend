using Core.Business.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes.CoursesFolder;

namespace Business.Rules.BusinessRules
{
    public class CourseBusinessRules : BaseBusinessRules
    {
        ICourseDal _courseDal;
        IExamService _examService;

        public CourseBusinessRules(ICourseDal courseDal, IExamService examService)
        {
            _courseDal = courseDal;
            _examService = examService;
        }

        public async Task ValidateExamPoint(int examPoint)
        {
            if (examPoint < 0 || examPoint > 100)
            {
                throw new BusinessException(BusinessMessages.ValidateExamPoint);
            }
        }


    }
}
