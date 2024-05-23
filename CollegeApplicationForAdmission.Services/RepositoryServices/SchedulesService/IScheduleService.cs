using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.SchedulesService
{
    public interface IScheduleService
    {
        Task<ICollection<Schedule>> GetAllAsync();
        Task<ICollection<Schedule>> GetSchedules();
        Task<Schedule> GetAsync(Guid id);
        Task<Schedule> GetSchedule(Guid id);
        Task<Schedule> CreateAsync(Schedule schedule);
        Task<Schedule> UpdateAsync(Schedule schedule);
        Task<Schedule> DeleteAsync(Guid id);
    }
}
