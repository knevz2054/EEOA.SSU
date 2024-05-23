using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class EducationalBackground
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public  Applicant Applicant { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string SchoolLastAttended { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string SchoolAddress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Track { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "LRN must be exactly 12 digits")]
        public string LRN { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Honors { get; set; }
        [Required(ErrorMessage = "This field is required")]     
        public int YearGraduated { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string SchoolSector { get; set; }
    }
}
