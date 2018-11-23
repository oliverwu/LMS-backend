using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface IStudentManager
    {
        bool CheckStudentExistByEmail(string email);
        bool CheckStudentExistById(int id);
        StudentDto CreateStudent(StudentAddDto student);
        void DeleteStudent(int id);
        StudentDto GetStudentById(int id);
        IEnumerable<StudentDto> SearchStudentsByName(string name);
        StudentDto UpdateStudent(StudentUpdateDto student);
        StudentSearchDto SearchStudent(SearchAttribute search);
    }
}
