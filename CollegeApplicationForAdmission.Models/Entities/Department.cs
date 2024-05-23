using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class Department : BaseCreated
    {
        [Required(ErrorMessage = "Create a department name")]
        public string Name { get; set; }

        // Foreign key property for the campus hosting the department
        public Guid CampusId { get; set; }
        public  Campus Campus { get; set; }

        // Navigation property for the courses under the department
        public  ICollection<Course> Courses { get; set; }
    }
}
