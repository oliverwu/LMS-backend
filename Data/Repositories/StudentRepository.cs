using Data.Database;
using Data.Repositories.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(LMSDBEntities context) : base(context)
        {

        }

        //public Student GetStudentByEmail(string email)
        //{
        //    return _context.Students.FirstOrDefault(x => x.Email == email);
        //}
    }
}
