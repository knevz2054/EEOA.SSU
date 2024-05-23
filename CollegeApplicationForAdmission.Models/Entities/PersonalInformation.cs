using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class PersonalInformation
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }
        public string? NameExtension { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string CivilStatus { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string PlaceOfBirth { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Citizenship { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Religion { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public string HouseNo { get; set; } = "";
        [Required(ErrorMessage = "This field is required.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Barangay { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Municipality { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Province { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int ZipCode { get; set; }

    }
}
