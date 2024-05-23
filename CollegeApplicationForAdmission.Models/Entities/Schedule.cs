using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class Schedule : BaseCreated
    {
        
        [Required(ErrorMessage = "Select Date Schedule")]
        public DateTime ScheduleDate { get; set; }

        [Required(ErrorMessage = "Venue is required")]
        public string Venue { get; set; }
        [Required(ErrorMessage = "Select Time")]
        public string Meridiem { get; set; }
        public int Slot { get; set; }
       
        public Guid CampusId { get; set; }
        public  Campus Campus { get; set; }

        // Navigation property for the applicants who have applied to this schedule
        public  ICollection<Applicant> Applicants { get; set; }

        //[NotMapped]
        ////public int Available
        ////{
        ////    //get { return Slot - (Applicants.Where(x => x.IsCompleted == true)?.Count() ?? 0); }
        ////    get { return Slot - (Applicants?.Count(x => x.IsCompleted) ?? 0); }
        ////}
        //public int Available => Count();

        ////public Schedule()
        ////{
        ////    Applicants = new List<Applicant>(); // Initialize the collection in the constructor
        ////}

        //int Count()
        //{
        //    return Slot - Applicants.Count(x => x.IsCompleted);
        //}

        [NotMapped]
        public int Available => CalculateAvailableSlots();

        // Method to calculate the number of available slots
        private int CalculateAvailableSlots()
        {
            if (Applicants == null || Applicants.Count == 0)
            {
                // If no applicants are associated with this schedule, all slots are available
                return Slot;
            }
            else
            {
                // Calculate the number of completed applicants
                int completedApplicantsCount = Applicants.Count(x => x.IsCompleted);

                // Calculate the number of available slots based on completed applicants
                int availableSlots = Slot - completedApplicantsCount;

                // Ensure that available slots are not negative
                return Math.Max(availableSlots, 0);
            }
        }
    }
}
