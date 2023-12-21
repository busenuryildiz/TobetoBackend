using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.Student;
using Business.Messages;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;

namespace Business.Rules
{
    public class StudentBusinessRules : BaseBusinessRules
    {
        private IStudentDal _studentDal;
        private static readonly Random _random = new Random();
        public StudentBusinessRules(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public async Task StudentNumberShouldBeUnique(int studentNumber)
        {
            var existingStudents = await _studentDal.GetListAsync(predicate: p => p.StudentNumber == studentNumber);

            if (existingStudents != null && existingStudents.Count > 0)
            {
                throw new BusinessException(BusinessMessages.StudentNumberShouldBeUnique);
            }
        }
    }
}
