using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.PersonalInformationsServices
{
    public interface IPersonalInformationService
    {
        Task<ICollection<PersonalInformation>> GetAllAsync();
        Task<PersonalInformation> GetAsync(Guid id);
        Task<PersonalInformation> CreateAsync(PersonalInformation information);
        Task<PersonalInformation> UpdateAsync(PersonalInformation information);
    }
}
