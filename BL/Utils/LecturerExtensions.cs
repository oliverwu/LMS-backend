using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utils
{
    public static class LecturerExtensions
    {

        public static IEnumerable<Lecturer> Search(this IEnumerable<Lecturer> lecturers, string value)
        {
            return lecturers.Where(x => x.Name.Contains(value)
                                    || x.Email.Contains(value));
        }

        public static IEnumerable<Lecturer> ApplySort(this IEnumerable<Lecturer> lecturers, string column, string order)
        {
            var isAscending = false;
            if (!string.IsNullOrEmpty(order))
            {
                isAscending = !(order.ToLower() == "desc");
            }
            switch (column.ToLower())
            {
                case "id":
                    return isAscending ? lecturers.OrderBy(x => x.Id) : lecturers.OrderByDescending(x => x.Id);
                case "name":
                    return isAscending ? lecturers.OrderBy(x => x.Name) : lecturers.OrderByDescending(x => x.Name);
                case "email":
                    return isAscending ? lecturers.OrderBy(x => x.Email) : lecturers.OrderByDescending(x => x.Email);
                case "staffNumber":
                    return isAscending ? lecturers.OrderBy(x => x.StaffNumber) : lecturers.OrderByDescending(x => x.StaffNumber);
                default:
                    return lecturers.OrderBy(x => x.Id);
            }
        }


    }
}
