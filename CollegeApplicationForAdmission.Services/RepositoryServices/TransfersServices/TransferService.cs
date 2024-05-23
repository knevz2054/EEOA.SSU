using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.TransfersServices
{
    public class TransferService : ITransferService
    {
        private readonly ApplicationDbContext _context;

        public TransferService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transfer> CreateAsync(Guid applicantId, User user, string fromCampus, string fromProgram, string toCampus, string toProgram)
        {
           Transfer transfer = new Transfer
            {
                ApplicantId = applicantId,
                UserId = user.Id,
                FromCampus = fromCampus,
                FromProgram = fromProgram,
                ToCampus = toCampus,
                ToProgram = toProgram,
                TransferredDate = DateTime.Now   
            };
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();

            return transfer;
        }

        public Task<Transfer> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Transfer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transfer> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
