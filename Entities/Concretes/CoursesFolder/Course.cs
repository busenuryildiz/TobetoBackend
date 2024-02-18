using Core.Entities;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.CoursesFolder
{
    public class Course : Entity<int>
    {
        public int? CourseLevelId { get; set; }
        public int? SoftwareLanguageId { get; set; }
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
        public double? Price { get; set; }
        public string? CourseType { get; set; }
        public int? Duration { get; set; }
        public string? Classroom { get; set; }
        public Category? Category { get; set; }
        public List<Assignment>? Assignments { get; set; }
        public List<Exam>? Exams { get; set; }
        public CourseLevel? CourseLevel { get; set; }
        public List<LessonCourse> LessonCourses { get; set; }
        public List<CourseSubject>? CourseSubjects { get; set; }
        public SoftwareLanguage? SoftwareLanguage { get; set; }
        public List<StudentCourse>? StudentCourses { get; set; } 
        public List<InstructorCourse> InstructorCourses { get; set; }
        public List<CoursePart> CourseParts { get; set; }
        public Badge? Badge { get; set; }

    }
}
