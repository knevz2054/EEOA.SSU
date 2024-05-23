using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.LogsServices
{
    public class LogService : ILogService
    {
        private readonly ApplicationDbContext _context;

        public LogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Log> CreateAsync(Log log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();

            return log;
        }

        public async Task<Log> DeleteAsync(Guid id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }
            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<ICollection<Log>> GetAllAsync()
        {
            var logs = await _context.Logs
              .Include(c => c.User)
              .ToListAsync();
            return logs;
        }

        public async Task<Log> GetAsync(Guid id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }
            return log;
        }
    }
}
