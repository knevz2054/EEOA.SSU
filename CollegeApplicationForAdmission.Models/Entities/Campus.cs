using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class Campus : BaseCreated
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public bool HasDepartment { get; set; } = false;

        // Navigation property for the departments in the campus
        public  ICollection<Department> Departments { get; set; }

        // Navigation property for the courses offered by the campus
        public  ICollection<Course> Courses { get; set; }

        // Navigation property for the schedules available for application in this campus
        public  ICollection<Schedule> Schedules { get; set; }
    }
}
