using AutoMapper;
using BL.Managers.Interfaces;
using Data.Repositories.Interfaces;
using Model.Dtos.Course;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class CourseManager : ICourseManager
    {
        private ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool CheckCourseExistById(int id)
        {
            return _courseRepository.Records.Any(x => x.Id == id);
        }

        public CourseDto Create(CourseAddDto course)
        {
            var newCourse = Mapper.Map<CourseAddDto, Course>(course);
            return Mapper.Map<Course, CourseDto>(_courseRepository.Add(newCourse));
        }

        public void Delete(int id)
        {
            Course course = _courseRepository.GetById(id);
            _courseRepository.Delete(course);
        }

        public CourseDto GetCourseById(int id)
        {
            var course = _courseRepository.GetById(id);
            return Mapper.Map<Course, CourseDto>(course);
        }

        public IEnumerable<CourseDto> SearchCoursesByName(string name)
        {
            var courses = _courseRepository.Records.Where(x => x.Title.Contains(name));
            return Mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);
        }

        public CourseDto Update(CourseUpdateDto course)
        {
            var newCourse = Mapper.Map<CourseUpdateDto, Course>(course);
            return Mapper.Map<Course, CourseDto>(_courseRepository.Update(newCourse));
        }
    }
}
