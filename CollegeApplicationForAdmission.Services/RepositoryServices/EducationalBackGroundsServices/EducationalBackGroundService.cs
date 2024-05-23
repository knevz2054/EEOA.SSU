using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using CollegeApplicationForAdmission.Services.RepositoryServices.ApplicantsServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.EducationalBackGroundsServices
{
    public class EducationalBackGroundService : IEducationalBackGroundService
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicantService _applicantService;

        public EducationalBackGroundService(ApplicationDbContext context, IApplicantService applicantService)
        {
            _context = context;
            _applicantService = applicantService;
        }
        public async Task<EducationalBackground> CreateAsync(EducationalBackground educational)
        {
            if (educational == null)
            {
                throw new ArgumentNullException(nameof(educational));
            }

            //var existingLRN = await _context.EducationalBackgrounds.FirstOrDefaultAsync(c => c.LRN.Trim() == educational.LRN.Trim());

            //if (existingLRN != null)
            //{
            //    throw new InvalidOperationException($"This LRN '{existingLRN.LRN}' already exists.");
            //}
            var query = await _applicantService.GetAllAsync();
            var countData = query.Count(x => x.IsCompleted);
            var existingLRN = query.Count(x => x.IsCompleted && x.EducationalBackground.LRN == educational.LRN);

            if (existingLRN > 0)
            {
                throw new InvalidOperationException($"This LRN '{educational.LRN}' already exists.");
            }

            await _context.EducationalBackgrounds.AddAsync(educational);
            await _context.SaveChangesAsync();

            return educational;
        }

        public async Task<ICollection<EducationalBackground>> GetAllAsync()
        {
            var backgrounds = await _context.EducationalBackgrounds
             .AsNoTracking()
             .ToListAsync();
            return backgrounds;
        }

        public async Task<EducationalBackground> GetAsync(Guid id)
        {
            var background = await _context.EducationalBackgrounds
             .AsNoTracking()
             .SingleOrDefaultAsync(a => a.Id == id);
            return background;
        }

        public async Task<EducationalBackground> UpdateAsync(EducationalBackground educational)
        {
            //_context.Entry(educational).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return educational;
            if (educational == null)
            {
                throw new ArgumentNullException(nameof(educational));
            }

            var existingLRN = await _context.EducationalBackgrounds
                                        .FirstOrDefaultAsync(c => c.Id != educational.Id && c.LRN == educational.LRN);

            if (existingLRN != null)
            {
                throw new InvalidOperationException($"LRN '{educational.LRN}' already exists.");
            }

            var existingBackground = await _context.Applicants.FindAsync(educational.Id);

            if (existingBackground != null)
            {
                // Detach the existing tracked entity
                _context.Entry(existingBackground).State = EntityState.Detached;
            }

            _context.Entry(educational).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return educational;
        }
    }
}
