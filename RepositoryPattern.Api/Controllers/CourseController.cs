using Microsoft.AspNetCore.Mvc;
using Repository.Domain.Entities;
using RepositoryPattern.Services.Services.Abstracts;
using System.Linq;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("Add")]
        public IActionResult Post(Course course)
        {
            var courseDto = new Course
            {                 
                CourseAdress = course.CourseAdress,
                CourseName = course.CourseName,
                CourseType = course.CourseType,
                TrainerEmail = course.TrainerEmail,
                TrainerName = course.TrainerName,

                CreatedBy = "Admin",
                CreatedDate = System.DateTime.Now,
                IsDeleted = false,
                LastModifiedDate = System.DateTime.Now
                
            };
            this._courseService.Add(courseDto);
            return Ok(courseDto);
        }

        [HttpGet("GetAllCourses")]
        public IActionResult GetAll()
        {
            var CourseList = _courseService.GetAll();   
            return Ok(CourseList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course= _courseService.GetById(id);

            if (course.Any())
                return Ok(course);
            return BadRequest("There is no course with this id! Ensure enter a valid id.");

        }

        [HttpPut("Update")]
        public IActionResult Update(Course course)
        {            
            _courseService.Update(course);
            return Ok(course);           
        }

        [HttpDelete]
        public IActionResult Delete(Course course)
        {
            _courseService.Delete(course);
            return Ok();
        }

    }
}
