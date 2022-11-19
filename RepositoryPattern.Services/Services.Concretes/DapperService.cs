using AutoMapper;
using Repository.Domain.Entities;
using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Domain.DTOs;
using RepositoryPattern.Services.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Services.Concretes
{
    public class DapperService : IDapperService
    {
        private readonly IDapperRepository _dapperRepository;
        private readonly IMapper _mapper;   
        public DapperService(IDapperRepository dapperRepository , IMapper mapper)
        {
            _dapperRepository = dapperRepository;
            _mapper = mapper;
        }
        public void AddAsync(Course course)
        {
            _dapperRepository.AddAsync(course);
        }

        public void DeleteAsync(int CourseId)
        {
            _dapperRepository.DeleteAsync(CourseId);
        }

        public List<Course> GetAllAsync()
        {
            return _dapperRepository.GetAllAsync();
        }

        public Course GetByIdAsync(int CourseId)
        {
            return _dapperRepository.GetByIdAsync(CourseId).Result; 
        }

        //public async Task Update(int id,CourseDto course)
        //{
        //    var result = _dapperRepository.GetByIdAsync(id).Result;
        //    if (result is null)
        //        throw new Exception("Not found.");            

        //    var updatedResult =_mapper.Map<Course>(course);
        //    updatedResult.CourseId = id;
        //    await _dapperRepository.Update(updatedResult);
        //}

        public void Update(CourseDto course, int id)
        {
            var course = _dapperRepository.GetByIdAsync(id);
            var courseUpdated = _mapper.Map<CourseDto>(course);
            _dapperRepository.Update(courseUpdated, id);
        }
    }
}
