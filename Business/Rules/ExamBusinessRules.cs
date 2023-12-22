using AutoMapper;
using Business.DTOs.Response.Question;
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
        IMapper _mapper;
        public ExamBusinessRules(IExamDal examDal, IMapper mapper)
        {
            _examDal = examDal;
            _mapper = mapper;
        }

        public async Task ValidateExamPoint(int examPoint)
        {
            if (examPoint < 0 || examPoint > 100)
            {
                throw new BusinessException(BusinessMessages.ValidateExamPoint);
            }
        }

        public async Task<List<GetListQuestionResponse>> GetRandomQuestionsByExamId(int examId)
        {
            var exam = await _examDal.GetAsync(e => e.Id == examId);

            if (exam == null)
            {
                if (exam.Questions == null || exam.Questions.Count == 0)
                {
                    throw new BusinessException(BusinessMessages.CantGetRandomQuestionsByExamId);
                }
            }

            var randomQuestions = exam.Questions.OrderBy(q => Guid.NewGuid()).Take(5).ToList();

            var result = randomQuestions.Select(q => _mapper.Map<GetListQuestionResponse>(q)).ToList();

            return result;



        }

    }
}
