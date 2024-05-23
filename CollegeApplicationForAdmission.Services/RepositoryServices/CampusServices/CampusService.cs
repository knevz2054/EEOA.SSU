using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.CampusServices
{
    public class CampusService : ICampusService
    {
        private readonly ApplicationDbContext _context;

        public CampusService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Campus> CreateAsync(Campus campus)
        {
            if (campus == null)
            {
                throw new ArgumentNullException(nameof(campus));
            }

            // Check if the name already exists
            var existingCampus = await _context.Campuses.FirstOrDefaultAsync(c => c.Name == campus.Name);

            if (existingCampus != null)
            {
                throw new InvalidOperationException($"A campus with the name '{campus.Name}' already exists.");
            }

            // If the name doesn't exist, proceed with adding the new Campus
            await _context.Campuses.AddAsync(campus);
            await _context.SaveChangesAsync();

            return campus;
        }

        public async Task<Campus> DeleteAsync(Guid id)
        {
            var campus = await _context.Campuses.FindAsync(id);
            if (campus == null)
            {
                throw new ArgumentNullException(nameof(campus));
            }
            _context.Campuses.Remove(campus);
            await _context.SaveChangesAsync();
            return campus;
        }

        public async Task<ICollection<Campus>> GetAllAsync()
        {
            var campuses = await _context.Campuses
                .Include(c => c.Departments)
                .Include(c => c.Courses)
                .Include(c => c.Schedules)
                    .ThenInclude(s => s.Applicants)
                    .ThenInclude(s => s.PersonalInformation)
                .Include(cd => cd.Schedules)
                    .ThenInclude(sd => sd.Applicants)
                    .ThenInclude(sd => sd.EducationalBackground)
                .Include(ce => ce.Schedules)
                    .ThenInclude(se => se.Applicants)
                    .ThenInclude(se => se.ParentGuardianInformation)
                .AsNoTracking()
                .ToListAsync();

            return campuses;
        }

        public async Task<Campus> GetAsync(Guid id)
        {
            var campus = await _context.Campuses
                .Include(c => c.Departments)
                .Include(c => c.Courses)
                 .Include(c => c.Schedules)
                    .ThenInclude(s => s.Applicants)
                    .ThenInclude(s => s.PersonalInformation)
                .Include(cd => cd.Schedules)
                    .ThenInclude(sd => sd.Applicants)
                    .ThenInclude(sd => sd.EducationalBackground)
                .Include(ce => ce.Schedules)
                    .ThenInclude(se => se.Applicants)
                    .ThenInclude(se => se.ParentGuardianInformation)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);
            if (campus == null)
            {
                throw new ArgumentNullException(nameof(campus));
            }
            return campus;
        }

        public async Task<Campus> GetCampusAsync(Guid id)
        {
            var campus = await _context.Campuses
                //.Include(c => c.Schedules)
              .SingleOrDefaultAsync(c => c.Id == id);
            if (campus == null)
            {
                throw new ArgumentNullException(nameof(campus));
            }
            return campus;
        }

        public async Task<ICollection<Campus>> GetCampusNoApplicant()
        {
            var campuses = await _context.Campuses
                 .Include(c => c.Departments)
                 .Include(c => c.Courses)
                  .Include(c => c.Schedules)
                  .ToListAsync();
            return campuses;
        }

        public async Task<Campus> UpdateAsync(Campus campus)
        {
            var campusExist = await _context.Campuses.SingleOrDefaultAsync(c => c.Name == campus.Name && c.Id != campus.Id);
            if (campusExist != null)
            {
                throw new InvalidOperationException($"A campus with the name '{campus.Name}' already exists.");
            }
            _context.Entry(campus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return campus;
        }
    }
}
