using AutoMapper;
using Model.Dtos;
using Model.Dtos.Course;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.App_Start
{
    public class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Student, StudentDto>();
                config.CreateMap<StudentDto, Student>();
                config.CreateMap<StudentAddDto, Student>();
                config.CreateMap<StudentUpdateDto, Student>();
                config.CreateMap<CourseAddDto, Course>();
                config.CreateMap<Course, CourseDto>();
                config.CreateMap<CourseUpdateDto, Course>();
                //config.CreateMap<Course, CourseDto>();
            });
        }

    }
}