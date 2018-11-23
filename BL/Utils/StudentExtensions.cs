using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utils
{
    public static class StudentExtensions
    {
        public static IEnumerable<Student> Search(this IEnumerable<Student> students, string value)
        {
            return students.Where(x => x.FirstName.Contains(value)
                                    || x.LastName.Contains(value)
                                    || x.Email.Contains(value));
        }

        public static IEnumerable<Student> ApplySort(this IEnumerable<Student> students, string column, string order)
        {
            var isAscending = false;
            if (!string.IsNullOrEmpty(order))
            {
                isAscending = !(order.ToLower() == "desc");
            }
            switch (column.ToLower())
            {
                case "id":
                    return isAscending ? students.OrderBy(x => x.Id) : students.OrderByDescending(x => x.Id);
                case "name":
                    return isAscending ? students.OrderBy(x => x.FirstName) : students.OrderByDescending(x => x.FirstName);
                case "email":
                    return isAscending ? students.OrderBy(x => x.Email) : students.OrderByDescending(x => x.Email);
                case "dateofbirth":
                    return isAscending ? students.OrderBy(x => x.DateOfBirth) : students.OrderByDescending(x => x.DateOfBirth);
                default:
                    return students.OrderBy(x => x.Id);
            }
        }
    }
}
