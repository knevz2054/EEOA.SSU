using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.ParentGuardianInformationsServices
{
    public interface IParentGuardianInformationService
    {
        Task<ICollection<ParentGuardianInformation>> GetAllAsync();
        Task<ParentGuardianInformation> GetAsync(Guid id);
        Task<ParentGuardianInformation> CreateAsync(ParentGuardianInformation information);
        Task<ParentGuardianInformation> UpdateAsync(ParentGuardianInformation information);
    }
}
