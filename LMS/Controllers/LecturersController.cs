using BL.Managers;
using BL.Managers.Interfaces;
using Model.Dtos.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    [Authorize]
    public class LecturersController : ApiController
    {
        private ILecturerManager _lecturerManager;

        public LecturersController(ILecturerManager lecturerManager)
        {
            _lecturerManager = lecturerManager;
        }

        [HttpGet]
        [Route("api/Lecturers")]
        public IHttpActionResult GetLecturerById(int id)
        {
            if (_lecturerManager.CheckLecturerExistById(id))
            {
                return Ok(_lecturerManager.GetById(id));
            }
            return BadRequest("This lecturer is not exist!!!");

        }

        [HttpGet]
        [Route("api/Lecturers")]
        public IHttpActionResult SearchLecturersByName(string name)
        {
            return Ok(_lecturerManager.SearchLecturersByName(name));
        }

        [HttpGet]
        [Route("api/Lecturers")]
        public IHttpActionResult GetLecturersByPage(int pageSize = 10, int pageNumber = 1)
        {
            SearchAttribute search = new SearchAttribute()
            {
                SearchValue = "",
                SortOrder = "asc",
                SortString = "id",
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            LecturerSearchDto students =_lecturerManager.SearchLecturer(search);
            return Ok(students);
        }


        [HttpPost]
        [Route("api/Lecturers")]
        public IHttpActionResult UpdateLecturer([FromBody]LecturerUpdateDto lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(state => state.Value.Errors).Aggregate("", (current, error) => current + (error.ErrorMessage + ". ")));
            }
            if (!_lecturerManager.CheckLecturerExistById(lecturer.Id))
            {
                return BadRequest("This student is not exist!!!");
            }
            return Ok(_lecturerManager.Update(lecturer));
        }


        [HttpPut]
        [Route("api/Lecturers")]
        public IHttpActionResult CreateLecturer([FromBody]LecturerAddDto lecturer)
        {
            if (lecturer == null)
            {
                return BadRequest("The parameter is null!!!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(state => state.Value.Errors).Aggregate("", (current, error) => current + (error.ErrorMessage + ". ")));
            }
            return Ok(_lecturerManager.Create(lecturer));

        }

        [HttpDelete]
        [Route("api/Lecturers")]
        public IHttpActionResult DeleteLecturer(int id)
        {
            if (_lecturerManager.CheckLecturerExistById(id))
            {
               _lecturerManager.Delete(id);
                return Ok("Succeed!");
            }
            return BadRequest("The result is not existed!!!");
        }


    }
}
