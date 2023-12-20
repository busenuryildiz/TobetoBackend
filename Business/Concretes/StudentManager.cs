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
using DataAccess.Concretes;

namespace Business.Concretes
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        IMapper _mapper;
        StudentBusinessRules _businessRules;
        IUserService _userManager;
        IUserDal _userDal;
        public StudentManager(StudentBusinessRules businessRules, IStudentDal studentDal, IMapper mapper, IUserService userManager, IUserDal userDal)
        {
            _businessRules = businessRules;
            _studentDal = studentDal;
            _userDal = userDal;
            _mapper = mapper;
            _userManager = userManager;
            _userDal = userDal;
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
            var student = await _studentDal.GetAsync(i => i.Id == deleteStudentRequest.Id);

            if (student != null)
            {
                // Öğrenciye ait kullanıcıyı bul
                var user = await _userDal.GetAsync(u => u.Id == student.UserId);

                if (user != null)
                {
                    try
                    {
                        // Öğrenciyi ve kullanıcıyı sil
                        await _userDal.DeleteAsync(user, true);
                        await _studentDal.DeleteAsync(student, true);

                        // Her ikisi de başarıyla silindi, silinen öğrenci bilgilerini dön
                        var deletedStudentResponse = _mapper.Map<DeletedStudentResponse>(student);
                        return deletedStudentResponse;
                    }
                    catch (Exception ex)
                    {
                        // Silme işlemi başarısız oldu, hata durumu ele alınmalı
                        // Örneğin:
                        // Loglama veya throw new Exception(ex.Message); gibi bir işlem yapılabilir.
                        return null;
                    }
                }
                else
                {
                    // Öğrenciye ait kullanıcı bulunamadı, hata durumu ele alınmalı
                    // Örneğin:
                    // throw new Exception("Öğrenciye ait kullanıcı bulunamadı.");
                    return null;
                }
            }
            else
            {
                // Öğrenci bulunamadı, hata durumu ele alınmalı
                // Örneğin:
                // throw new Exception("Öğrenci bulunamadı.");
                return null;
            }
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

