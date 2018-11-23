using AutoMapper;
using BL.Managers.Interfaces;
using Data.Repositories.Interfaces;
using Model.Dtos.Lecturer;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Utils;

namespace BL.Managers
{
    public class LecturerManager : ILecturerManager
    {
        private ILecturerRepository _lecturerRepository;

        public LecturerManager(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        public bool CheckLecturerExistById(int id)
        {
            return _lecturerRepository.Records.Any(x => x.Id == id);
        }

        public LecturerDto Create(LecturerAddDto lecturer)
        {
            var newLecturer = Mapper.Map<LecturerAddDto, Lecturer>(lecturer);
            return Mapper.Map<Lecturer, LecturerDto>(_lecturerRepository.Add(newLecturer));
        }

        public void Delete(int id)
        {
            Lecturer lecturer = _lecturerRepository.GetById(id);
            _lecturerRepository.Delete(lecturer);
        }

        public LecturerDto GetById(int id)
        {
            var Lecturer = _lecturerRepository.GetById(id);
            return Mapper.Map<Lecturer, LecturerDto>(Lecturer);
        }

        public LecturerSearchDto SearchLecturer(SearchAttribute search)
        {
            if (search.PageNumber == 0)
            {
                search.PageNumber = 1;
            }
            if (search.PageSize == 0)
            {
                search.PageSize = 10;
            }

            var lecturers = _lecturerRepository.Records.Search(search.SearchValue);
            lecturers = lecturers.ApplySort(search.SortString, search.SortOrder);

            var SearchResult = new LecturerSearchDto
            {
                PageSize = search.PageSize,
                TotalPage = lecturers.Count() / search.PageSize + (lecturers.Count() % search.PageSize == 0 ? 0 : 1),
                Amount = lecturers.Count()
            };

            SearchResult.PageNumber = search.PageNumber > SearchResult.TotalPage ? 1 : search.PageNumber;

            SearchResult.Lecturers = Mapper.Map<IEnumerable<Lecturer>, IEnumerable<LecturerDto>>(lecturers.Skip((SearchResult.PageNumber - 1) * SearchResult.PageSize).Take(SearchResult.PageSize));
            return SearchResult;
        }

        public IEnumerable<LecturerDto> SearchLecturersByName(string name)
        {
            return Mapper.Map<IEnumerable<Lecturer>, IEnumerable<LecturerDto>>(_lecturerRepository.Records.Where(x => x.Name.Contains(name)));
        }

        public LecturerDto Update(LecturerUpdateDto lecturer)
        {
            var newLecturer = Mapper.Map<LecturerUpdateDto, Lecturer>(lecturer);
            return Mapper.Map<Lecturer, LecturerDto>(_lecturerRepository.Update(newLecturer));
        }
    }
}
