using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.AuthServices
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(string passwordHash, string inputPassword);
        string Hash(string password);

    }
}
