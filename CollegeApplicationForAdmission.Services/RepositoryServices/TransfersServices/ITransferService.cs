using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.TransfersServices
{
    public interface ITransferService
    {
        Task<ICollection<Transfer>> GetAllAsync();
        Task<Transfer> GetAsync(Guid id);
        Task<Transfer> CreateAsync(Guid applicantId, User user, string fromCampus, string fromProgram, string toCampus, string toProgram);
        Task<Transfer> DeleteAsync(Guid id);
    }
}
