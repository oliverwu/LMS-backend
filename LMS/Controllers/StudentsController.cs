using BL.Managers;
using BL.Managers.Interfaces;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    //[Authorize]
    public class StudentsController : ApiController
    {
        private readonly IStudentManager _studentManager;

        public StudentsController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpGet]
        [Route("api/Students")]
        public IHttpActionResult GetStudentsByPage(int pageSize = 10, int pageNumber = 1)
        {
            SearchAttribute search = new SearchAttribute()
            {
                SearchValue ="",
                SortOrder = "asc",
                SortString = "id",
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            StudentSearchDto students = _studentManager.SearchStudent(search);
            return Ok(students);
        }



        [HttpGet]
        [Route("api/Students")]
        public IHttpActionResult GetStudentById(int id)
        {
            return Ok(_studentManager.GetStudentById(id));
        }

        [HttpGet]
        [Route("api/Studnets")]
        public IHttpActionResult SearchStudentsByName(string name)
        {
            return Ok(_studentManager.SearchStudentsByName(name));
        }


        [HttpPost]
        [Route("api/Students")]
        public IHttpActionResult UpdateStudent([FromBody]StudentUpdateDto student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(state => state.Value.Errors).Aggregate("", (current, error) => current + (error.ErrorMessage + ". ")));
            }
            if (_studentManager.CheckStudentExistById(student.Id))
            {
                return BadRequest("This student is not exist!!!");
            }
            return Ok(_studentManager.UpdateStudent(student));
        }

       
        [HttpPut]
        [Route("api/Students")]
        public IHttpActionResult CreateNewStudent([FromBody]StudentAddDto student)
        {
            if (student == null)
            {
                return BadRequest("The parameter is null!!!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(state => state.Value.Errors).Aggregate("", (current, error) => current + (error.ErrorMessage + ". ")));
            }
            if (_studentManager.CheckStudentExistByEmail(student.Email))
            {
                return BadRequest("This student is alread existed!!");
            }
            //return Ok();
            return Ok(_studentManager.CreateStudent(student));
                
        }

        [HttpDelete]
        [Route("api/Students")]
        public IHttpActionResult DeleteStudent(int id)
        {
            if (_studentManager.CheckStudentExistById(id))
            {
                _studentManager.DeleteStudent(id);
                return Ok("Succeed!");
            }
            return BadRequest("The result is not existed!!!");
        }
    }
}
