using AutoMapper;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Microsoft.EntityFrameworkCore;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes.CoursesFolder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.DTOs.Response.Course
{
    public class GetListCourseByDynamicQuery : IRequest<CourseListModel>
    {
        public DynamicQuery? Dynamic { get; set; }
        public PageRequest? PageRequest { get; set; }

        public class GetListCourseByDynamicQueryHandler : IRequestHandler<GetListCourseByDynamicQuery, CourseListModel>
        {
            private readonly IMapper _mapper;
            private readonly ICourseDal _courseDal;

            public GetListCourseByDynamicQueryHandler(ICourseDal courseDal, IMapper mapper)
            {
                _mapper = mapper;
                _courseDal = courseDal;
            }

            public async Task<CourseListModel> Handle(GetListCourseByDynamicQuery request, CancellationToken cancellationToken)
            {
                if (request.Dynamic == null || request.PageRequest == null)
                {
                    throw new ArgumentException("Invalid request parameters.");
                }

                IPaginate<Entities.Concretes.CoursesFolder.Course> courses = await _courseDal.GetListByDynamicAsync(
                    request.Dynamic,
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize
                );

                IList<GetListCourseResponse> mappedCourses = _mapper.Map<IList<GetListCourseResponse>>(courses.Items);

                return new CourseListModel
                {
                    Items = mappedCourses
                };
            }
        }
    }
    public class CourseListModel : BasePageableModel
    {
        public IList<GetListCourseResponse>? Items { get; set; }
    }
}
