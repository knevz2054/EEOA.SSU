using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.LogsServices
{
    public interface ILogService
    {
        Task<ICollection<Log>> GetAllAsync();
        Task<Log> GetAsync(Guid id);
        Task<Log> CreateAsync(Log log);
        Task<Log> DeleteAsync(Guid id);
    }
}
