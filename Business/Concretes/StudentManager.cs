using AutoMapper;
using Business.DTOs.Request.Student;
using Business.DTOs.Response.Student;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Microsoft.EntityFrameworkCore;
using Business.Rules.BusinessRules;
using Serilog;
using Business.DTOs.Response.User;
using System.Drawing;

namespace Business.Concretes
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        IMapper _mapper;
        StudentBusinessRules _businessRules;
        public StudentManager(IStudentDal studentDal, IMapper mapper, StudentBusinessRules businessRules)
        {
            _studentDal = studentDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }
        public async Task<CreatedStudentResponse> Add(CreateStudentRequest createStudentRequest)
        {
            try
            {
                // DTO'dan Entity'e dönüştürme
                Student student = _mapper.Map<Student>(createStudentRequest);

                // Generate a unique student number
                GenerateUniqueStudentNumber(student);

                // Öğrenciyi veritabanına ekle
                Student createdStudent = await _studentDal.AddAsync(student);

                // Oluşturulan öğrenciyi response nesnesine dönüştür
                CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(createdStudent);

                // Başarılı durumu döndür
                return createdStudentResponse;
            }
            catch (Exception ex)
            {
                // Hata mesajını ve iç hatayı logla
                Log.Error(ex.Message, "An error occurred while adding a student");

                // Hata durumunda uygun bir cevap veya istisna fırlatılabilir
                throw new Exception("Failed to create student.", ex.InnerException);
            }
        }


        public async Task<DeletedStudentResponse> Delete(DeleteStudentRequest deleteStudentRequest)
        {
            Student student = await _studentDal.GetAsync(i => i.Id == deleteStudentRequest.Id);
            var deletedStudent = await _studentDal.DeleteAsync(student);
            DeletedStudentResponse deletedStudentResponse = _mapper.Map<DeletedStudentResponse>(deletedStudent);
            return deletedStudentResponse;
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
                include: u => u
                    .Include(c => c.ApplicationStudents)
                    .Include(c => c.StudentAssignments)
                    .Include(c => c.StudentCourses),
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
            await _studentDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedStudentResponse>(data);
            return result;
        }
        public async Task<Student> GetStudentByUserIdAsync(Guid userId)
        {
            // Öğrenciyi kullanıcı kimliğine göre almak için lambda ifadesi kullanarak sorgu yapabilirsiniz
            return await _studentDal.GetAsync(student => student.UserId == userId);
        }





        private void GenerateUniqueStudentNumber(Student student)
        {
            int maxAttempts = 10; // You can adjust the maximum number of attempts as needed
            int attempt = 0;

            do
            {
                // Generate a random student number
                string studentNumber = new Random().Next(1000, 99999).ToString();

                // Check if the generated student number is unique
                if (_studentDal.GetAsync(s => s.StudentNumber == studentNumber).Result == null)
                {
                    // If unique, set the student number and break out of the loop
                    student.StudentNumber = studentNumber;
                    break;
                }

                // If not unique, try again
                attempt++;

                if (attempt >= maxAttempts)
                {
                    // Handle the case where a unique student number couldn't be generated after maximum attempts
                    throw new Exception("Failed to generate a unique student number.");
                }
            } while (true);
        }

        public async Task<GetStudentSkillsResponse> GetStudentSkillsByUserIdAsync(Guid userId)
        {
            var student = await _studentDal.GetAsync(student => student.UserId == userId,
                                                        include: query=>query
                                                        .Include(s=>s.StudentSkills)
                                                            .ThenInclude(s=>s.Skill));

            var result = _mapper.Map<GetStudentSkillsResponse>(student);

            return result;
           
        }

        public Student GetStudentByUserId(Guid userId)
        {
            var student =  _studentDal.Get(s => s.UserId == userId);

            return student;
        }
    }

}

