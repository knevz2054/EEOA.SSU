using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.CoursesServices
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Course> CreateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            if (course.CampusId == Guid.Empty)
            {
                throw new InvalidOperationException($"Selecting a campus is required.");
            }
            var campus = await _context.Campuses.FindAsync(course.CampusId);
            if (campus != null)
            {
                if (campus.HasDepartment == true && course.DepartmentId == null)
                {
                    throw new InvalidOperationException($"Selecting a department is required.");
                }
            }           

            // Check if the name already exists
            var existingCourse = await _context.Courses
                .FirstOrDefaultAsync(d => d.Name == course.Name && d.CampusId == course.CampusId);

            if (existingCourse != null)
            {
                throw new InvalidOperationException($"A course with the name '{course.Name}' already exists.");
            }

            // If the name doesn't exist, proceed with adding the new Course
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> DeleteAsync(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<ICollection<Course>> GetAllAsync()
        {
            var courses = await _context.Courses
               .Include(c => c.Campus)
               .Include(c => c.Department)
               .AsNoTracking()
               .ToListAsync();
            return courses;
        }

        public async Task<Course> GetAsync(Guid id)
        {
            var course = await _context.Courses
               .Include(c => c.Campus)
               .Include(c => c.Department)
               .AsNoTracking()
               .SingleOrDefaultAsync(x => x.Id == id);
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            return course;
        }
        public async Task<Course> UpdateAsync(Course course)
        {
            var courseExist = await _context.Courses
                 .SingleOrDefaultAsync(c => c.Name == course.Name && c.Id != course.Id && c.CampusId == course.CampusId);
            if (courseExist != null)
            {
                throw new InvalidOperationException($"A course with the name '{course.Name}' already exists.");
            }
            var originalCourse = await _context.Courses.FindAsync(course.Id);

            if (originalCourse == null)
            {
                throw new ArgumentException($"Course with ID '{course.Id}' not found.");
            }

            // Update the properties of the original campus with the new values
            _context.Entry(originalCourse).CurrentValues.SetValues(course);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return course;
        }
    }
}
