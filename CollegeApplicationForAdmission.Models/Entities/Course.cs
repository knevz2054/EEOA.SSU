using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class Course : BaseCreated
    {
        [Required]
        public string Name { get; set; }

        // Foreign key property for the department offering the course
        public Guid? DepartmentId { get; set; }
        public  Department Department { get; set; }

        // Foreign key property for the campus offering the course
        public Guid CampusId { get; set; }
        public  Campus Campus { get; set; }
        public bool IsFlag { get; set; } = false;
    }
}
