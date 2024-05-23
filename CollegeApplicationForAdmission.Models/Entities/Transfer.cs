using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class Transfer
    {
        public Guid Id { get; set; }
        public string FromCampus { get; set; }
        public string FromProgram { get; set; }
        public string ToCampus { get; set; }
        public string ToProgram { get; set; }
        public Guid ApplicantId { get; set; }
        public DateTime TransferredDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
