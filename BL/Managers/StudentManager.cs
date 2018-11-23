using AutoMapper;
using BL.Managers.Interfaces;
using BL.Utils;
using Data.Repositories.Interfaces;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class StudentManager : IStudentManager
    {
        private IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool CheckStudentExistByEmail(string email)
        {
            return _studentRepository.Records.Any(x => x.Email == email);
        }

        public bool CheckStudentExistById(int id)
        {
            return _studentRepository.Records.Any(x => x.Id == id);
        }

        public StudentDto CreateStudent(StudentAddDto student)
        {         
            var newStudent = Mapper.Map<StudentAddDto, Student>(student);
            return Mapper.Map < Student, StudentDto > (_studentRepository.Add(newStudent));
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepository.GetById(id);
            _studentRepository.Delete(student);
        }

        public StudentDto GetStudentById(int id)
        {
            return Mapper.Map<Student, StudentDto>(_studentRepository.GetById(id));
        }

        public IEnumerable<StudentDto> SearchStudentsByName(string name)
        {
            return Mapper.Map < IEnumerable<Student> , IEnumerable<StudentDto> > (_studentRepository.Records.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name)));
        }

        public StudentDto UpdateStudent(StudentUpdateDto student)
        {
            var newStudent = Mapper.Map<StudentUpdateDto, Student>(student);
            return Mapper.Map < Student, StudentDto >(_studentRepository.Update(newStudent));
        }

        public StudentSearchDto SearchStudent(SearchAttribute search)
        {
            if (search.PageNumber == 0)
            {
                search.PageNumber = 1;
            }
            if (search.PageSize == 0)
            {
                search.PageSize = 10;
            }
            var students = _studentRepository.Records.Search(search.SearchValue);
            students = students.ApplySort(search.SortString, search.SortOrder);

            var SearchResult = new StudentSearchDto
            {
                PageSize = search.PageSize,
                TotalPage = students.Count() / search.PageSize + (students.Count() % search.PageSize == 0 ? 0 : 1)
            };

            SearchResult.PageNumber = search.PageNumber > SearchResult.TotalPage ? 1 : search.PageNumber;

            SearchResult.Students = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(students.Skip((SearchResult.PageNumber - 1) * SearchResult.PageSize).Take(SearchResult.PageSize));
            return SearchResult;
        }


    }
}
