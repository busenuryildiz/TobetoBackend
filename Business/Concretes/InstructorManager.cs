using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Instructor;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Instructor;
using Business.DTOs.Response.User;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        IMapper _mapper;
        InstructorBusinessRules _businessRules;
        IUserService _userManager;
        IUserDal _userDal;
        public InstructorManager(InstructorBusinessRules businessRules, IInstructorDal instructorDal, IMapper mapper, IUserService userManager, IUserDal userDal)
        {
            _businessRules = businessRules;
            _instructorDal = instructorDal;
            _userDal = userDal;
            _mapper = mapper;
            _userManager = userManager;
            _userDal = userDal;
        }

        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            // Instructor için gerekli alanları doldur
            Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);

            // Kullanıcı oluşturmak için CreateUserRequest nesnesini oluştur
            CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(createInstructorRequest);

            // Kullanıcı eklemek için IUserService kullan
            CreatedUserResponse createdUserResponse = await _userManager.Add(createUserRequest);

            // Eğer kullanıcı başarıyla eklendiyse devam et
            if (createdUserResponse != null)
            {
                instructor.UserId = createdUserResponse.Id; // Oluşturulan kullanıcının Id'sini instructor'ın UserId özelliğine ata

                // Instructor'ı veritabanına ekle
                Instructor createdInstructor = await _instructorDal.AddAsync(instructor);

                // Oluşturulan Instructor'ı CreatedInstructorResponse nesnesine dönüştür
                CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(createdInstructor);

                // Oluşturulan öğrenciyi ve kullanıcıyı içeren sonuç nesnesini döndür
                return createdInstructorResponse;
            }

            // Kullanıcı eklenemediyse null döndür veya hata durumunu ele al
            return null;
        }

        //public async Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest)
        //{
        //    var data = await _instructorDal.GetAsync(i => i.Id == deleteInstructorRequest.Id);
        //    _mapper.Map(deleteInstructorRequest, data);
        //    data.DeletedDate = DateTime.Now;
        //    var result = await _instructorDal.DeleteAsync(data, true);
        //    var result2 = _mapper.Map<DeletedInstructorResponse>(result);
        //    return result2;
        //}

        public async Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest)
        {
            var instructor = await _instructorDal.GetAsync(i => i.Id == deleteInstructorRequest.Id);

            if (instructor != null)
            {
                // Öğrenciye ait kullanıcıyı bul
                var user = await _userDal.GetAsync(u => u.Id == instructor.UserId);

                if (user != null)
                {
                    try
                    {
                        // Öğrenciyi ve kullanıcıyı sil
                        await _userDal.DeleteAsync(user, true);
                        await _instructorDal.DeleteAsync(instructor, true);

                        // Her ikisi de başarıyla silindi, silinen öğrenci bilgilerini dön
                        var deletedInstructorResponse = _mapper.Map<DeletedInstructorResponse>(instructor);
                        return deletedInstructorResponse;
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








        public async Task<CreatedInstructorResponse> GetById(Guid id)
        {
            var result = await _instructorDal.GetAsync(c => c.Id == id);
            Instructor mappedInstructor = _mapper.Map<Instructor>(result);

            CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(mappedInstructor);

            return createdInstructorResponse;
        }

        public async Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _instructorDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListInstructorResponse>>(data);
            return result;
        }

        public async Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest)
        {
            var data = await _instructorDal.GetAsync(i => i.Id == updateInstructorRequest.Id);
            _mapper.Map(updateInstructorRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _instructorDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedInstructorResponse>(data);
            return result;
        }
    }
}
