using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.EducationalBackGroundsServices
{
    public interface IEducationalBackGroundService
    {
        Task<ICollection<EducationalBackground>> GetAllAsync();
        Task<EducationalBackground> GetAsync(Guid id);
        Task<EducationalBackground> CreateAsync(EducationalBackground educational);
        Task<EducationalBackground> UpdateAsync(EducationalBackground educational);
    }
}
