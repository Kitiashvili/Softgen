using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class MapperInitilizer: Profile
    {
        public MapperInitilizer()
        {
            CreateMap<StudentsDTO, Students>()
                .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
            CreateMap<Students, StudentsDTO>();
            CreateMap<TeacherDTO, Teacher>()
                .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<CourseDTO, Course>()
                .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
            CreateMap<Course, CourseDTO>();

        }
    }
}
