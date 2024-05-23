using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.ApplicantsServices
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Applicant> CreateAsync(Applicant applicant)
        {
           
            if (applicant == null)
            {
                throw new ArgumentNullException(nameof(applicant));
            }
            // If the name doesn't exist, proceed with adding the new Course
            await _context.Applicants.AddAsync(applicant);
            await _context.SaveChangesAsync();

            return applicant;
        }

        public async Task DeleteAllAsync(IEnumerable<Applicant> applicants)
        {           
            var applicantIds = applicants.Select(a => a.Id).ToList();

            foreach (var id in applicantIds)
            {
                var applicant = await _context.Applicants.FindAsync(id);
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Applicant> DeleteAsync(Guid Id)
        {
            var applicant = await _context.Applicants.FindAsync(Id);
            if (applicant == null)
            {
                throw new ArgumentNullException(nameof(applicant));
            }
            _context.Applicants.Remove(applicant);
            await _context.SaveChangesAsync();

            return applicant;
        }

        public async Task<ICollection<Applicant>> GetAllAsync()
        {
            var applicants = await _context.Applicants
               .Include(a => a.Schedule)
                    .ThenInclude(a => a.Campus)
               .Include(ba => ba.PersonalInformation)
               .Include(ca => ca.EducationalBackground)
               .Include(da => da.ParentGuardianInformation)
               .AsNoTracking()
               .ToListAsync();


            
            return applicants;
        }

        public async Task<Applicant> GetAsync(Guid id)
        {
            var applicant = await _context.Applicants
               .Include(a => a.Schedule)
                     .ThenInclude(s => s.Campus)
               .Include(ba => ba.PersonalInformation)
               .Include(ca => ca.EducationalBackground)
               .Include(da => da.ParentGuardianInformation)
               .AsNoTracking()
               .SingleOrDefaultAsync(a => a.Id == id);

            
            return applicant; // Return null if applicant is not found
        }
        public async Task<Applicant> UpdateAsync(Applicant applicant)
        {
            
            if (applicant == null)
            {
                throw new ArgumentNullException(nameof(applicant));
            }

            if(applicant.ControlNo != null)
            {
                var existingControl = await _context.Applicants
                                        .FirstOrDefaultAsync(c =>  c.Id != applicant.Id && c.ControlNo == applicant.ControlNo);

                if (existingControl != null)
                {
                    throw new InvalidOperationException($"Control # '{applicant.ControlNo}' already exists.");
                }
            }
            

            var existingApplicant = await _context.Applicants.FindAsync(applicant.Id);

            if (existingApplicant != null)
            {
                // Detach the existing tracked entity
                _context.Entry(existingApplicant).State = EntityState.Detached;
            }

            // Modify the state of the passed applicant entity
            _context.Entry(applicant).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return applicant;
        }
    }
}
