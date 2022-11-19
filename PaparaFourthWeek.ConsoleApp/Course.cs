using System;

namespace PaparaFourthWeek.ConsoleApp
{
    public class Course
    {
        public int CourseId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; } //It can be null.
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public string CourseAdress { get; set; }
        public string TrainerName { get; set; }
        public string TrainerEmail { get; set; }
    }
}
