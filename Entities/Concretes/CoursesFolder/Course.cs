using Core.Entities;
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
        public int? Duration { get; set; }
        public Category? Category { get; set; }
        public List<Assignment>? Assignments { get; set; }
        public List<Exam>? Exams { get; set; }
        public CourseLevel? CourseLevel { get; set; }
        public List<LessonCourse> LessonCourses { get; set; }
        public List<CourseSubject>? CourseSubjects { get; set; }
        public SoftwareLanguage? SoftwareLanguage { get; set; }
        public List<StudentCourse>? StudentCourses { get; set; } 
        public List<InstructorCourse> InstructorCourses { get; set; }
        public List<ClassroomOfCourse> ClassroomOfCourses { get; set; }

    }
}
