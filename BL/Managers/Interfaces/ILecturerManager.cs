using Model.Dtos.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface ILecturerManager
    {
        bool CheckLecturerExistById(int id);
        LecturerDto Create(LecturerAddDto lectuer);
        void Delete(int id);
        LecturerDto GetById(int id);
        IEnumerable<LecturerDto> SearchLecturersByName(string name);
        LecturerDto Update(LecturerUpdateDto lecturer);
        LecturerSearchDto SearchLecturer(SearchAttribute search);
    }
}
