using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.ParentGuardianInformationsServices
{
    public class ParentGuardianInformationService : IParentGuardianInformationService
    {
        private readonly ApplicationDbContext _context;

        public ParentGuardianInformationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ParentGuardianInformation> CreateAsync(ParentGuardianInformation information)
        {
            await _context.ParentGuardianInformations.AddAsync(information);
            await _context.SaveChangesAsync();

            return information;
        }

        public async Task<ParentGuardianInformation> UpdateAsync(ParentGuardianInformation information)
        {
            _context.Entry(information).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return information;
        }

        public async Task<ICollection<ParentGuardianInformation>> GetAllAsync()
        {
            var guardians = await _context.ParentGuardianInformations
             .AsNoTracking()
             .ToListAsync();
            return guardians;
        }

        public async Task<ParentGuardianInformation> GetAsync(Guid id)
        {
            var guardian = await _context.ParentGuardianInformations
              .AsNoTracking()
              .SingleOrDefaultAsync(a => a.Id == id);
            return guardian;
        }
    }
}
