using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Option;
using Business.DTOs.Response.Option;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;

namespace Business.Concretes
{
    public class OptionManager : IOptionService
    {
        private readonly IOptionDal _repository;
        private readonly IMapper _mapper;

        public OptionManager(IOptionDal repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetListOptionResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _repository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListOptionResponse>>(data);
            return result;
        }

        public async Task<CreatedOptionResponse> Add(CreateOptionRequest createOptionRequest)
        {
            var option = _mapper.Map<Option>(createOptionRequest);
            var createdOption = await _repository.AddAsync(option);
            var result = _mapper.Map<CreatedOptionResponse>(createdOption);
            return result;
        }

        public async Task<UpdatedOptionResponse> Update(UpdateOptionRequest updateOptionRequest)
        {
            var option = await _repository.GetAsync(o => o.Id == updateOptionRequest.Id);
            _mapper.Map(updateOptionRequest, option);
            await _repository.UpdateAsync(option);
            var result = _mapper.Map<UpdatedOptionResponse>(option);
            return result;
        }

        public async Task<DeletedOptionResponse> Delete(DeleteOptionRequest deleteOptionRequest)
        {
            var option = await _repository.GetAsync(o => o.Id == deleteOptionRequest.Id);
            var deletedOption = await _repository.DeleteAsync(option);
            var result = _mapper.Map<DeletedOptionResponse>(deletedOption);
            return result;
        }

        public async Task<IPaginate<Option>> GetOptionsByQuestionId(int questionId)
        {
            return await _repository.GetListAsync(o => o.QuestionId == questionId);
        }

        public async Task<Option> AddOptionToQuestion(int questionId, CreateOptionRequest createOptionRequest)
        {
            var option = _mapper.Map<Option>(createOptionRequest);
            option.QuestionId = questionId;

            return await _repository.AddAsync(option);
        }

        public async Task<CreatedOptionResponse> GetById(int id)
        {
            var result = await _repository.GetAsync(c => c.Id == id);
            Option mappedOption = _mapper.Map<Option>(result);
            CreatedOptionResponse createdOptionResponse = _mapper.Map<CreatedOptionResponse>(mappedOption);
            return createdOptionResponse;
        }
    }

}
