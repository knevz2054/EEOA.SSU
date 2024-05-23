using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class ParentGuardianInformation
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public  Applicant Applicant { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public string FatherFirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string FatherMiddleName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string FatherLastName { get; set; }
        public string? FatherContactNo { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string FatherCitizenship { get; set; }
        public string? FatherEmail { get; set; }
        public string? FatherOccupation { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MotherFirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MotherMiddleName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MotherLastName { get; set; }
        public string? MotherContactNo { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MotherCitizenship { get; set; }
        public string? MotherEmail { get; set; }
        public string? MotherOccupation { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string GuardianFirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string GuardianMiddleName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string GuardianLastName { get; set; }
        public string? GuardianContactNo { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string GuardianCitizenship { get; set; }
        public string? GuardianEmail { get; set; }
        public string? GuardianOccupation { get; set; }
    }
}
