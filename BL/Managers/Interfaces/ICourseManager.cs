using Model.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface ICourseManager
    {
        bool CheckCourseExistById(int id);
        CourseDto Create(CourseAddDto course);
        void Delete(int id);
        CourseDto GetCourseById(int id);
        IEnumerable<CourseDto> SearchCoursesByName(string name);
        CourseDto Update(CourseUpdateDto course);
        //CourseSearchDto SearchCourse(SearchAttribute search);
    }
}
