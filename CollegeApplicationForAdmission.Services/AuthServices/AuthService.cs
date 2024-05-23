using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;

namespace CollegeApplicationForAdmission.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(ApplicationDbContext dbContext, IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public async Task<User> CreateAsync(User user)
        {
            var existing = await _dbContext.Users.AnyAsync(u => u.Username == user.Username);
            if (existing)
                throw new UsernameAlreadyInUseException();


            var passwordHash = _passwordHasher.Hash(user.Password);
            user.Password = passwordHash;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(Guid Id)
        {
            var user = await _dbContext.Users.FindAsync(Id);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(x => x.Logs)
                .ToListAsync();
        }

        public async Task<User> GetAsync(Guid Id)
        {
            var data = await _dbContext.Users
                .Include(x => x.Logs)
                .SingleOrDefaultAsync(x => x.Id == Id);

            if (data == null)
            {
                throw new UserNotFoundException();
            }
            return data;
        }

        public async Task<User> Login(string username, string password)
        {           
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var result = _passwordHasher.VerifyPassword(user.Password, password);
            if (!result)
            {
                throw new UserNotFoundException();
            }
            var login = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username && result);


            return user;

        }

        public async Task<User> UpdateAsync(User user)
        {
            // Check if newPassword is provided and update the password hash
            var newPasswordHash = _passwordHasher.Hash(user.Password);
            user.Password = newPasswordHash;

            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return user;

        }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found") { }
    }

    public class UsernameAlreadyInUseException : Exception
    {
        public UsernameAlreadyInUseException() : base("Username already in use") { }
    }
}
