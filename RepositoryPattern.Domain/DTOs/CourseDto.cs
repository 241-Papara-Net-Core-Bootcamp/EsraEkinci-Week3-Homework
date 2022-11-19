using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.DTOs
{
    public class CourseDto
    {
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public string CourseAdress { get; set; }
        public string TrainerName { get; set; }
        public string TrainerEmail { get; set; }
    }
}
