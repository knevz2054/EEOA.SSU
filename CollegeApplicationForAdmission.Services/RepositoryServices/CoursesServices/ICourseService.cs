using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.CoursesServices
{
    public interface ICourseService
    {
        Task<ICollection<Course>> GetAllAsync();
        Task<Course> GetAsync(Guid id);
        Task<Course> CreateAsync(Course course);
        Task<Course> UpdateAsync(Course course);
        Task<Course> DeleteAsync(Guid id);
    }
}
