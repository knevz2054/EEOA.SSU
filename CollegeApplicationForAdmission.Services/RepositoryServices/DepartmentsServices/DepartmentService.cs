using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.DepartmentsServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Department> CreateAsync(Department department)
        {
            if(department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            if(department.CampusId == Guid.Empty)
            {
                throw new InvalidOperationException($"Selecting a campus is required.");
            }

            // Check if the name already exists
            var existingDepartment = await _context.Departments
                .FirstOrDefaultAsync(d => d.Name == department.Name && d.CampusId == department.CampusId);

            if (existingDepartment != null)
            {
                throw new InvalidOperationException($"A department with the name '{department.Name}' already exists.");
            }

            // If the name doesn't exist, proceed with adding the new Department
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return department;
        }

        public async Task<Department> DeleteAsync(Guid id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<ICollection<Department>> GetAllAsync()
        {
            var departments = await _context.Departments
                .Include(d => d.Campus)
                .Include(d => d.Courses)
                .AsNoTracking()
                .ToListAsync();
            return departments;
        }

        public async Task<Department> GetAsync(Guid id)
        {
            var department = await _context.Departments
                .Include(d => d.Campus)
                .Include(d => d.Courses)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            return department;
        }

        public async Task<Department> UpdateAsync(Department department)
        {
            var departmentExist = await _context.Departments
                .SingleOrDefaultAsync(d => d.Name == department.Name && d.Id != department.Id && d.CampusId == department.CampusId);
            if (departmentExist != null)
            {
                throw new InvalidOperationException($"A department with the name '{department.Name}' already exists.");
            }
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
