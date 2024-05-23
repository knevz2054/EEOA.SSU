using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.CampusServices
{
    public interface ICampusService
    {
        Task<ICollection<Campus>> GetAllAsync();
        Task<ICollection<Campus>> GetCampusNoApplicant();
        Task<Campus> GetAsync(Guid id);
        Task<Campus> GetCampusAsync(Guid id);
        Task<Campus> CreateAsync(Campus campus);
        Task<Campus> UpdateAsync(Campus campus);
        Task<Campus> DeleteAsync(Guid id);
    }
}
