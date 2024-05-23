using CollegeApplicationForAdmission.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }       
        public DbSet<EducationalBackground> EducationalBackgrounds { get; set; }
        public DbSet<ParentGuardianInformation> ParentGuardianInformations { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
               .HasOne(a => a.PersonalInformation)
               .WithOne(pi => pi.Applicant)
               .HasForeignKey<PersonalInformation>(pi => pi.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade); // Cascade delete for personal information

            modelBuilder.Entity<Applicant>()
                .HasOne(a => a.EducationalBackground)
                .WithOne(eb => eb.Applicant)
                .HasForeignKey<EducationalBackground>(eb => eb.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete for educational background

            modelBuilder.Entity<Applicant>()
                .HasOne(a => a.ParentGuardianInformation)
                .WithOne(pgi => pgi.Applicant)
                .HasForeignKey<ParentGuardianInformation>(pgi => pgi.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete for parent guardian information

            // Your other configurations...

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading proxies
        //    //optionsBuilder.UseSqlServer("Server=10.0.0.6,1435;Database=ApplicationAdmissionDb;User ID=sa;Password=@ICTserver;Encrypt=False;");
        //    optionsBuilder.UseSqlServer("Server=knevz2054\\sqlexpress;Database=ApplicationAdmissionDb;Trusted_Connection=True;TrustServerCertificate=true;");
        //}
    }
}
