using Repository.Domain.Entities;
using RepositoryPattern.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Abstracts
{
    public interface IDapperRepository
    {
        Task<Course> GetByIdAsync(int id);
        List<Course> GetAllAsync();
        void AddAsync(Course entity);
        
        void DeleteAsync(int CourseId);
        Task Update(Course course);
    }
}
