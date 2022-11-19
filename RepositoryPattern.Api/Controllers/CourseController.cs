using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Domain.Entities;
using RepositoryPattern.Domain.DTOs;
using RepositoryPattern.Services.Services.Abstracts;
using System.Collections.Generic;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //private readonly ICourseService _courseService;
        private readonly IDapperService _dapperService;
        private readonly IMapper _mapper;

        public CourseController( IDapperService dapperService , IMapper mapper)
        {
            //_courseService = courseService;
            _mapper = mapper;
            _dapperService = dapperService;
        }

        [HttpPost("Add")]
        public IActionResult Post(CourseDto course)
        {
            _dapperService.AddAsync(_mapper.Map<Course>(course));
            return Ok(course);         

            
        }

        [HttpGet("GetAllCourses")]
        public IActionResult GetAllAsync()
        {
            var CourseList = _dapperService.GetAllAsync();
            var courseMap = _mapper.Map<List<CourseDto>>(CourseList);
            return Ok(courseMap);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _dapperService.GetByIdAsync(id);
            //var courseDto = _mapper.Map<CourseDto>(course);
            if (course is not null)
                return Ok(course);
            return BadRequest("Not Found.");
            //if (course.Any())
                //return Ok(courseDto);
            //return BadRequest("There is no course with this id! Ensure enter a valid id.");
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, CourseDto course)
        {
            var result = _dapperService.GetByIdAsync(id);
            if (result is null)
                return BadRequest("Not Found");
            _dapperService.Update(course, id);
            return Ok(course);

            //_dapperService.Update(id,course);
            //return Ok();
            //_dapperService.UpdateAsync(_mapper.Map<Course>(course));
            //return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var course = _dapperService.GetByIdAsync(id);
            if (course is null)
                return BadRequest("Nor Found");
            _dapperService.DeleteAsync(id);
            return Ok();    
            //return Ok($"Success! The data that has {id} number is deleted.");
        }

    }

}


