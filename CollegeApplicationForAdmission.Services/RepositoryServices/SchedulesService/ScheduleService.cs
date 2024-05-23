using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.SchedulesService
{
    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext _context;

        public ScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Schedule> CreateAsync(Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            // Check if the name already exists
            var existingSchedule = await _context.Schedules.FirstOrDefaultAsync(s => s.ScheduleDate == schedule.ScheduleDate && s.CampusId == schedule.CampusId && s.Meridiem == schedule.Meridiem);

            if (existingSchedule != null)
            {
                throw new InvalidOperationException($"A schedule with date '{schedule.ScheduleDate.ToShortDateString()}' in selected campus already exists.");
            }

            // If the name doesn't exist, proceed with adding the new Campus
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }

        public async Task<Schedule> DeleteAsync(Guid id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }
        public async Task<ICollection<Schedule>> GetAllAsync()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Campus)
                //    .ThenInclude(c => c.Courses)
                .Include(spi => spi.Applicants)
                    .ThenInclude(api => api.PersonalInformation)
                .Include(sbg => sbg.Applicants)
                    .ThenInclude(abg => abg.EducationalBackground)
                .Include(sfg => sfg.Applicants)
                    .ThenInclude(afg => afg.ParentGuardianInformation)
                .AsNoTracking()
                .ToListAsync();
            return schedules;
        }

        public async Task<Schedule> GetAsync(Guid id)
        {
            var schedule = await _context.Schedules
                 .Include(s => s.Campus)
                 //    .ThenInclude(c => c.Courses)
                  .Include(spi => spi.Applicants)
                    .ThenInclude(api => api.PersonalInformation)
                .Include(sbg => sbg.Applicants)
                    .ThenInclude(abg => abg.EducationalBackground)
                .Include(sfg => sfg.Applicants)
                    .ThenInclude(afg => afg.ParentGuardianInformation)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(x => x.Id == id);
            return schedule;
        }

        public async Task<Schedule> GetSchedule(Guid id)
        {
            var schedule = await _context.Schedules
                 .Include(s => s.Campus)
                 .ThenInclude(c => c.Courses)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(x => x.Id == id);
            return schedule;
        }

        public async Task<ICollection<Schedule>> GetSchedules()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Campus)
                .ThenInclude(c => c.Courses)
                .AsNoTracking()
                .ToListAsync();
            return schedules;
        }

        public async Task<Schedule> UpdateAsync(Schedule schedule)
        {
            _context.Entry(schedule).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return schedule;
        }
    }
}
