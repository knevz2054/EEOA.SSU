using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public string Process { get; set; }       
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public  User User { get; set; }
    }
}
