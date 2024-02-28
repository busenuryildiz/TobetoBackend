using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Lesson
{
    public class CreatedLessonResponse
    {
        public int? Id { get; set; }
        public int? CourseId { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public string? VideoUrl { get; set; }
        public int? CoursePartId { get; set; }
        public DateTime? LessonDuration { get; set; }
        public DateTime? LessonDateAndHour { get; set; }
        public string? Speaker { get; set; }
        public string? AboutSpeaker { get; set; }
    }
}