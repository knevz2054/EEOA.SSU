using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.DepartmentsServices
{
    public interface IDepartmentService
    {
        Task<ICollection<Department>> GetAllAsync();
        Task<Department> GetAsync(Guid id);
        Task<Department> CreateAsync(Department department);
        Task<Department> UpdateAsync(Department department);
        Task<Department> DeleteAsync(Guid id);
    }
}
