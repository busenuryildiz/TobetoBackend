using Core.Business.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstracts;
using Business.Abstracts;
using Business.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Concretes;

namespace Business.Rules
{
    public class StudentCourseBusinessRules : BaseBusinessRules
    {
            IStudentCourseDal _studentCourseDal;
            IExamService _examService;
            StudentCourseBusinessRules _businessRules;

            public StudentCourseBusinessRules(IStudentCourseDal studentCourseDal, IExamService examService, StudentCourseBusinessRules businessRules)
            {
                _examService = examService;
                _businessRules = businessRules;
                _studentCourseDal = studentCourseDal;
            }
            public async Task CertificateCanNotBeGivenDueToProgress(int examId, int studentCourseId)
            {
                var studentCourse = await _studentCourseDal.GetAsync(s=>s.Id == studentCourseId);
                var exam = await _examService.GetById(examId);


                if (studentCourse != null && exam != null)
                {
                    if (studentCourse.Progress != 100 || exam.Point < 60)
                    {
                        throw new BusinessException(BusinessMessages.CertificateCanNotBeGivenDueToProgress);
                    }
                }
                throw new BusinessException(BusinessMessages.CourseOrExamNotFound);


            }

        }
}
