using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.ApplicantsServices
{
    public interface IApplicantService
    {
        Task<ICollection<Applicant>> GetAllAsync();
        Task<Applicant> GetAsync(Guid id);
        Task<Applicant> CreateAsync(Applicant applicant);
        Task<Applicant> DeleteAsync(Guid Id);
        Task DeleteAllAsync(IEnumerable<Applicant> applicants);
        Task<Applicant> UpdateAsync(Applicant applicant);
    }
}
