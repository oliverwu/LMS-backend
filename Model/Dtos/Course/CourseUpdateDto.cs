using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.Course
{
    public class CourseUpdateDto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Fee")]
        [Range(0, 9999.99)]
        public decimal Fee { get; set; }
        [Display(Name = "Max Student")]
        [Range(0, 60)]
        public int MaxStudent { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Language")]
        public string Language { get; set; }
    }
}
