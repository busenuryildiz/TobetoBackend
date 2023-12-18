using AutoMapper;
using Business.DTOs.Request.Student;
using Business.DTOs.Response.Student;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.DTOs.Request.User;
using Business.DTOs.Response.User;

namespace Business.Concretes
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        IMapper _mapper;
        StudentBusinessRules _businessRules;
        IUserService _userManager;
        public StudentManager(StudentBusinessRules businessRules, IStudentDal studentDal, IMapper mapper, IUserService userManager)
        {
            _businessRules = businessRules;
            _studentDal = studentDal;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CreatedStudentResponse> Add(CreateStudentRequest createStudentRequest)
        {
            // Student için gerekli alanları doldur
            Student student = _mapper.Map<Student>(createStudentRequest);
            student.GenerateStudentNumber(); // Öğrenci numarasını oluştur

            // Kullanıcı oluşturmak için CreateUserRequest nesnesini oluştur
            CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(createStudentRequest);

            // Kullanıcı eklemek için IUserService kullan
            CreatedUserResponse createdUserResponse = await _userManager.Add(createUserRequest);

            // Eğer kullanıcı başarıyla eklendiyse devam et
            if (createdUserResponse != null)
            {
                student.UserId = createdUserResponse.Id; // Oluşturulan kullanıcının Id'sini student'ın UserId özelliğine ata

                // Student'ı veritabanına ekle
                Student createdStudent = await _studentDal.AddAsync(student);

                // Oluşturulan Student'ı CreatedStudentResponse nesnesine dönüştür
                CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(createdStudent);

                // Oluşturulan öğrenciyi ve kullanıcıyı içeren sonuç nesnesini döndür
                return createdStudentResponse;
            }

            // Kullanıcı eklenemediyse null döndür veya hata durumunu ele al
            return null;
        }

        public async Task<DeletedStudentResponse> Delete(DeleteStudentRequest deleteStudentRequest)
        {
            var data = await _studentDal.GetAsync(i => i.Id == deleteStudentRequest.Id);
        _mapper.Map(deleteStudentRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _studentDal.DeleteAsync(data, true);
        var result2 = _mapper.Map<DeletedStudentResponse>(result);
            return result2;
        }

    public async Task<CreatedStudentResponse> GetById(Guid id)
    {
        var result = await _studentDal.GetAsync(c => c.Id == id);
        Student mappedStudent = _mapper.Map<Student>(result);

        CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(mappedStudent);

        return createdStudentResponse;
    }

    public async Task<IPaginate<GetListStudentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _studentDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );
        var result = _mapper.Map<Paginate<GetListStudentResponse>>(data);
        return result;
    }

    public async Task<UpdatedStudentResponse> Update(UpdateStudentRequest updateStudentRequest)
    {
        var data = await _studentDal.GetAsync(i => i.Id == updateStudentRequest.Id);
        _mapper.Map(updateStudentRequest, data);
        data.UpdatedDate = DateTime.Now;
        await _studentDal.UpdateAsync(data);
        var result = _mapper.Map<UpdatedStudentResponse>(data);
        return result;
    }
}
}

