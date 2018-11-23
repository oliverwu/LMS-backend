using BL.Managers.Interfaces;
using Model.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    [Authorize]
    public class CoursesController : ApiController
    {
        private ICourseManager _courseManager;

        public CoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet]
        [Route("api/Courses")]
        public IHttpActionResult GetCourseById(int id)
        {
            if (_courseManager.CheckCourseExistById(id))
            {
                return Ok(_courseManager.GetCourseById(id));
            }
            return BadRequest("This course is not exist!!!");
            
        }

        [HttpGet]
        [Route("api/Courses")]
        public IHttpActionResult SearchCoursesByName(string name)
        {
            return Ok(_courseManager.SearchCoursesByName(name));
        }

        [HttpGet]
        [Route("api/Courses")]
        public IHttpActionResult GetAllCourses()
        {
            return Ok(_courseManager.SearchCoursesByName(""));
        }


        [HttpPost]
        [Route("api/Courses")]
        public IHttpActionResult UpdateCourse([FromBody]CourseUpdateDto course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(state => state.Value.Errors).Aggregate("", (current, error) => current + (error.ErrorMessage + ". ")));
            }
            if (!_courseManager.CheckCourseExistById(course.Id))
            {
                return BadRequest("This student is not exist!!!");
            }
            return Ok(_courseManager.Update(course));
        }


        [HttpPut]
        [Route("api/Courses")]
        public IHttpActionResult CreateCourse([FromBody]CourseAddDto course)
        {
            if (course == null)
            {
                return BadRequest("The parameter is null!!!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(state => state.Value.Errors).Aggregate("", (current, error) => current + (error.ErrorMessage + ". ")));
            }
            return Ok(_courseManager.Create(course));

        }

        [HttpDelete]
        [Route("api/Courses")]
        public IHttpActionResult DeleteCourse(int id)
        {
            if (_courseManager.CheckCourseExistById(id))
            {
                _courseManager.Delete(id);
                return Ok("Succeed!");
            }
            return BadRequest("The result is not existed!!!");
        }

    }
}
