using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Question;
using Business.DTOs.Response.Question;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.CoursesFolder;

namespace Business.Concretes
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;
        private readonly IMapper _mapper;
        private readonly IOptionService _optionService;

        public QuestionManager(IQuestionDal questionDal, IOptionService optionService, IMapper mapper)
        {
            _questionDal = questionDal;
            _optionService = optionService;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetListQuestionResponse>> GetListAsync(PageRequest pageRequest)
        {
            var result = await _questionDal.GetListAsync(predicate: null, orderBy: null, include: null, index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<IPaginate<GetListQuestionResponse>>(result);
        }


        public async Task<UpdatedQuestionResponse> Update(UpdateQuestionRequest updateQuestionRequest)
        {
            var result = await _questionDal.UpdateAsync(_mapper.Map<Question>(updateQuestionRequest));
            return _mapper.Map<UpdatedQuestionResponse>(result);
        }

        public async Task<DeletedQuestionResponse> Delete(DeleteQuestionRequest deleteQuestionRequest)
        {
            var result = await _questionDal.DeleteAsync(_mapper.Map<Question>(deleteQuestionRequest));
            return _mapper.Map<DeletedQuestionResponse>(result);
        }

        public async Task<CreatedQuestionResponse> GetById(int id)
        {
            var result = await _questionDal.GetAsync(predicate: q => q.Id == id);
            return _mapper.Map<CreatedQuestionResponse>(result);
        }

        public async Task<List<GetListQuestionResponse>> GetQuestionsByExamId(int examId)
        {
            var result = await _questionDal.GetListAsync(predicate: q => q.ExamId == examId);
            return _mapper.Map<List<GetListQuestionResponse>>(result);
        }
    }
}
