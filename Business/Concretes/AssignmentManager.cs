using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Announcement;
using Business.DTOs.Request.Assignments;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Announcement;
using Business.DTOs.Response.Assignments;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Concretes.Courses;

namespace Business.Concretes
{
    public class AssignmentManager : IAssignmentService
    {
        IAssignmentDal _assignmentDal;
        IMapper _mapper;
        AssignmentBusinessRules _assignmentBusinessRules;
        public AssignmentManager(IAssignmentDal assignmentDal, IMapper mapper, AssignmentBusinessRules assignmentBusinessRules)
        {
            _assignmentDal = assignmentDal;
            _mapper = mapper;
            _assignmentBusinessRules = assignmentBusinessRules;
        }

        public async Task<CreatedAssignmentResponse> Add(CreateAssignmentRequest createAssignmentRequest)
        {
            await _assignmentBusinessRules.DoNotSendItAfterTheAssignmentPeriodIsOver(createAssignmentRequest.DeadLine);
            Assignment assignment = _mapper.Map<Assignment>(createAssignmentRequest);
            Assignment createdAssignment = await _assignmentDal.AddAsync(assignment);
            CreatedAssignmentResponse createdAssignmentResponse = _mapper.Map<CreatedAssignmentResponse>(createdAssignment);
            return createdAssignmentResponse;
        }

        public async Task<DeletedAssignmentResponse> Delete(DeleteAssignmentRequest deleteAssignmentRequest)
        {
            Assignment assignment = await _assignmentDal.GetAsync(i => i.Id == deleteAssignmentRequest.Id);
            assignment.DeletedDate = DateTime.Now;
            var deletedAssignment = await _assignmentDal.DeleteAsync(assignment);
            DeletedAssignmentResponse deletedAssignmentResponse = _mapper.Map<DeletedAssignmentResponse>(deletedAssignment);

            return deletedAssignmentResponse;


            //var data = await _assignmentDal.GetAsync(i => i.Id == deleteAssignmentRequest.Id);
            //_mapper.Map(deleteAssignmentRequest, data);
            //data.DeletedDate = DateTime.Now;
            //var result = await _assignmentDal.DeleteAsync(data);
            //var result2 = _mapper.Map<DeletedAssignmentResponse>(result);
            //return result2;
        }

        public async Task<CreatedAssignmentResponse> GetById(int id)
        {
            var result = await _assignmentDal.GetAsync(c => c.Id == id);
            Assignment mappedAssignment = _mapper.Map<Assignment>(result);

            CreatedAssignmentResponse createdAssignmentResponse = _mapper.Map<CreatedAssignmentResponse>(mappedAssignment);

            return createdAssignmentResponse;
        }


        public async Task<IPaginate<GetListAssignmentResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _assignmentDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListAssignmentResponse>>(data);
            return result;
        }


        public async Task<UpdatedAssignmentResponse> Update(UpdateAssignmentRequest updateAssignmentRequest)
        {
            Assignment assignment = await _assignmentDal.GetAsync(i => i.Id == updateAssignmentRequest.Id);
            assignment.UpdatedDate = DateTime.Now;
            var updatedAssignment = await _assignmentDal.UpdateAsync(assignment);
            UpdatedAssignmentResponse updatedAssignmentResponse =
                _mapper.Map<UpdatedAssignmentResponse>(updatedAssignment);

            return updatedAssignmentResponse;



            //var data = await _assignmentDal.GetAsync(i => i.Id == updateAssignmentRequest.Id);
            //_mapper.Map(updateAssignmentRequest, data);
            //data.UpdatedDate = DateTime.Now;
            //await _assignmentDal.UpdateAsync(data);
            //var result = _mapper.Map<UpdatedAssignmentResponse>(data);
            //return result;
        }
    }
}
