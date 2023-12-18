//using AutoMapper;
//using Business.DTOs.Request.Student;
//using Business.DTOs.Response.Student;
//using Business.Rules;
//using Core.DataAccess.Paging;
//using DataAccess.Abstract;
//using Entities.Concrete.Client;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Business.Abstract;

//namespace Business.Concrete
//{
//   public class StudentManager:IStudentService
//    {
//        IStudentDal _studentDal;
//        IMapper _mapper;
//        StudentBusinessRules _businessRules;

//        public StudentManager(StudentBusinessRules businessRules, IStudentDal studentDal, IMapper mapper)
//        {
//            _businessRules = businessRules;
//            _studentDal = studentDal;
//            _mapper = mapper;
//        }

//        public async Task<CreatedStudentResponse> Add(CreateStudentRequest createStudentRequest)
//        {
//            Student student = _mapper.Map<Student>(createStudentRequest);
//            Student createdStudent = await _studentDal.AddAsync(student);
//            CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(createdStudent);
//            return createdStudentResponse;
//        }

//        public async Task<DeletedStudentResponse> Delete(DeleteStudentRequest deleteStudentRequest)
//        {
//            var data = await _studentDal.GetAsync(i => i.Id == deleteStudentRequest.Id);
//            _mapper.Map(deleteStudentRequest, data);
//            data.DeletedDate = DateTime.Now;
//            var result = await _studentDal.DeleteAsync(data, true);
//            var result2 = _mapper.Map<DeletedStudentResponse>(result);
//            return result2;
//        }

//        public async Task<CreatedStudentResponse> GetById(Guid id)
//        {
//            var result = await _studentDal.GetAsync(c => c.Id == id);
//            Student mappedStudent = _mapper.Map<Student>(result);

//            CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(mappedStudent);

//            return createdStudentResponse;
//        }

//        public async Task<IPaginate<GetListStudentResponse>> GetListAsync(PageRequest pageRequest)
//        {
//            var data = await _studentDal.GetListAsync(
//                index: pageRequest.PageIndex,
//                size: pageRequest.PageSize
//            );
//            var result = _mapper.Map<Paginate<GetListStudentResponse>>(data);
//            return result;
//        }

//        public async Task<UpdatedStudentResponse> Update(UpdateStudentRequest updateStudentRequest)
//        {
//            var data = await _studentDal.GetAsync(i => i.Id == updateStudentRequest.Id);
//            _mapper.Map(updateStudentRequest, data);
//            data.UpdatedDate = DateTime.Now;
//            await _studentDal.UpdateAsync(data);
//            var result = _mapper.Map<UpdatedStudentResponse>(data);
//            return result;
//        }
//    }
//}

