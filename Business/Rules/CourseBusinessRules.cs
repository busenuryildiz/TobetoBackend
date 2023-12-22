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
using Entities.Concretes.Courses;

namespace Business.Rules
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
        public async Task CertificateCanNotBeGivenDueToProgress(int courseId, int examId)
        {
            var course = await _courseDal.GetAsync(c => c.Id == courseId);
            var exam = await _examService.GetById(examId);


            if (course != null && exam != null)
            {
                if (course.Progress != 100 || exam.Point < 60)
                {
                    throw new BusinessException(BusinessMessages.CertificateCanNotBeGivenDueToProgress);
                }
            }
                throw new BusinessException(BusinessMessages.CourseOrExamNotFound);
            

        }

    }
}
