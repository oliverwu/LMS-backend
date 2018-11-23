using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.Lecturer
{
    public class LecturerSearchDto
    {
        public IEnumerable<LecturerDto> Lecturers { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPage { get; set; }
        public int Amount { get; set; }
    }
}
