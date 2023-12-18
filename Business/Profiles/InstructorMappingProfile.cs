using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;
using Entities.Concrete.Client;

namespace Business.Profiles
{
    public class InstructorMappingProfile: Profile
    {
        CreateMap<CreateInstructorRequest, Instructor>().ReverseMap();
        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();

        CreateMap<DeleteInstructorRequest, Instructor>().ReverseMap();
        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();

        CreateMap<UpdateInstructorRequest, Instructor>().ReverseMap();
        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, GetListInstructorResponse>().ReverseMap();
        CreateMap<IPaginate<Instructor>, IPaginate<GetListInstructorResponse>>().ReverseMap();
    }
}
