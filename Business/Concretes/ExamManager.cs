using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Exam;
using Business.DTOs.Response.Exam;
using Business.DTOs.Response.Question;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class ExamManager : IExamService
    {
        private readonly IExamDal _examDal;
        private readonly IMapper _mapper;
        ExamBusinessRules _examBusinessRules;

        public ExamManager(IExamDal examDal, IMapper mapper, ExamBusinessRules examBusinessRules)
        {
            _examDal = examDal;
            _mapper = mapper;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _examDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListExamResponse>>(data);
            return result;
        }

        public async Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest)
        {
            // AutoMapper kullanarak DTO'dan Entity'e dönüşüm yapılıyor.
            var exam = _mapper.Map<Exam>(createExamRequest);

            // EF Core, Exam nesnesini ve ona bağlı tüm Question ve Option nesnelerini otomatik olarak ekler.
            await _examDal.AddAsync(exam);

            // Sonuç olarak oluşturulan Exam nesnesini DTO'ya dönüştürüyoruz.
            var result = _mapper.Map<CreatedExamResponse>(exam);

            return result;
        }


        public async Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest)
        {
            var examDal = await _examDal.GetAsync(e => e.Id == updateExamRequest.Id);
            _mapper.Map(updateExamRequest, examDal);
            await _examDal.UpdateAsync(examDal);
            var result = _mapper.Map<UpdatedExamResponse>(examDal);
            return result;
        }

        public async Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest)
        {
            var examDal = await _examDal.GetAsync(e => e.Id == deleteExamRequest.Id);
            var deletedExam = await _examDal.DeleteAsync(examDal);
            var result = _mapper.Map<DeletedExamResponse>(deletedExam);
            return result;
        }

        public async Task<CreatedExamResponse> GetById(int id)
        {
            var result = await _examDal.GetAsync(c => c.Id == id);
            Exam mappedExam = _mapper.Map<Exam>(result);
            CreatedExamResponse createdExamResponse = _mapper.Map<CreatedExamResponse>(mappedExam);
            return createdExamResponse;
        }


        public async Task<List<GetListExamResponse>> GetExamsByCourseId(int courseId)
        {
            var examDals = await _examDal.GetListAsync(e => e.CourseId == courseId);
            var result = _mapper.Map<List<GetListExamResponse>>(examDals);
            return result;
        }

        public async Task<List<GetListQuestionResponse>> GetRandomQuestionsByExamId(int examId)
        {
            var exam = await _examDal.GetAsync(e => e.Id == examId, include: q => q.Include(e => e.Questions).ThenInclude(q => q.Options));
            var questions = exam.Questions;

            // Soruları GetListQuestionResponse listesine dönüştür
            var result = _mapper.Map<List<GetListQuestionResponse>>(questions);

            return result;
        }
        public async Task<StudentExamResultDto> SubmitExamResults(SubmitExamResultDto submitExamResultDto)
        {
            // Sınav sorularını al
            var exam = await _examDal.GetAsync(e => e.Id == submitExamResultDto.ExamId, include: q => q.Include(e => e.Questions).ThenInclude(q => q.Options));
            var questions = exam.Questions;

            // Sınav sonuçlarını hesapla
            var examResult = CalculateExamResult(submitExamResultDto.Answers, questions);

            // StudentExamResult entity'sini oluştur
            var studentExamResult = new StudentExamResult
            {
                StudentId = submitExamResultDto.StudentId,
                ExamId = submitExamResultDto.ExamId,
                CorrectAnswers = examResult.CorrectAnswers,
                WrongAnswers = examResult.WrongAnswers,
                Unanswered = examResult.Unanswered
            };

            // Sonuçları veritabanına kaydet
            //await _studentExamResultDal.AddAsync(studentExamResult);

            // Kaydedilen sonuçları DTO olarak dön
            var result = _mapper.Map<StudentExamResultDto>(studentExamResult);
            return result;
        }
        public ExamResultDto CalculateExamResult(List<UserAnswerDto> userAnswers, List<Question> questions)
        {
            var result = new ExamResultDto();

            foreach (var question in questions)
            {
                var userAnswer = userAnswers.FirstOrDefault(ua => ua.QuestionId == question.Id);

                // Kullanıcı bu soruya cevap vermemişse
                if (userAnswer == null || userAnswer.SelectedOptionId == null)
                {
                    result.Unanswered++;
                    continue;
                }

                // Kullanıcının verdiği cevap doğru mu?
                var correctOption = question.Options.FirstOrDefault(o => o.IsCorrect);
                if (correctOption != null && userAnswer.SelectedOptionId == correctOption.Id)
                {
                    result.CorrectAnswers++;
                }
                else
                {
                    result.WrongAnswers++;
                }
            }

            return result;
        }

    }
}
