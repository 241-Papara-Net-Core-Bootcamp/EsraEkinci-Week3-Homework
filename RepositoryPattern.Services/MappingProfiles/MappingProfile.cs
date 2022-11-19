using AutoMapper;
using Repository.Domain;
using Repository.Domain.Entities;
using RepositoryPattern.Domain.DTOs;
using System;

namespace RepositoryPattern.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap();
            
        }
    }
}
