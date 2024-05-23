using CollegeApplicationForAdmission.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.AuthServices
{
    public interface IAuthService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetAsync(Guid Id);
        Task<User> Login(string username, string password);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(Guid Id);
    }
}
