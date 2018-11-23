using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.Lecturer
{
    public class LecturerUpdateDto
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        [Display(Name = "Staff Number")]
        public string StaffNumber { get; set; }
        [Required]
        [EmailAddress]       
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        [Display(Name = "Bibliography")]
        public string Bibliography { get; set; }
    }
}
