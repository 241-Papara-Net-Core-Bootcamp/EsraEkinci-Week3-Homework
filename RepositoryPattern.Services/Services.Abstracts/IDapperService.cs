using Repository.Domain.Entities;
using RepositoryPattern.Domain.DTOs;
using System.Collections.Generic;

namespace RepositoryPattern.Services.Services.Abstracts
{
    public interface IDapperService
    {
        Course GetByIdAsync(int id);
        List<Course> GetAllAsync();
        void AddAsync(Course course);
        
        void DeleteAsync(int CourseId);
        void Update(CourseDto course, int id);
    }
}
