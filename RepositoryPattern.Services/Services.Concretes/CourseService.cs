using Repository.Data.Abstracts;
using Repository.Domain.Entities;
using RepositoryPattern.Services.Services.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern.Services.Services.Concretes
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Add(Course course)
        {
            _courseRepository.Add(course);
        }

        public void Delete(Course course)
        {
            _courseRepository.Delete(course);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.UpdateGetAll().ToList();

        }

        public IEnumerable<Course> GetById(int id)
        {
            return _courseRepository.GetById(id);
        }


        public void Update(Course course)
        {
            _courseRepository.Update(course);
        }

        public IEnumerable<Course> UpdateGetAll()
        {
            return _courseRepository.UpdateGetAll();
        }
    }
}
