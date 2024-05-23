using CollegeApplicationForAdmission.Models.Entities;
using CollegeApplicationForAdmission.Services.DataContext;
using CollegeApplicationForAdmission.Services.RepositoryServices.ApplicantsServices;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Services.RepositoryServices.PersonalInformationsServices
{
    public class PersonalInformationService : IPersonalInformationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicantService _applicantService;

        public PersonalInformationService(ApplicationDbContext context, IApplicantService applicantService)
        {
            _context = context;
            _applicantService = applicantService;
        }
        public async Task<PersonalInformation> CreateAsync(PersonalInformation information)
        {
            if (information == null)
            {
                throw new ArgumentNullException(nameof(information));
            }

            // Validate that first name, middle name, and last name do not contain special characters
            if (!IsValidName(information.FirstName) ||
                !IsValidName(information.MiddleName) ||
                !IsValidName(information.LastName))
            {
                throw new ArgumentException("Your first name, middle name, and last name cannot contain special characters.");
            }

            if (!NoLeadingTrailingSpaceValidator.Validate(information.FirstName) ||
                !NoLeadingTrailingSpaceValidator.Validate(information.MiddleName) ||
                !NoLeadingTrailingSpaceValidator.Validate(information.LastName))
            {
                throw new ArgumentException("Your first name, middle name and last name cannot have leading or trailing spaces");
            }

            // Trim leading and trailing spaces from string properties
            information.FirstName = information.FirstName?.Trim();
            information.MiddleName = information.MiddleName?.Trim();
            information.LastName = information.LastName?.Trim();

            var applicants = await _applicantService.GetAllAsync();
            var isDuplicate = applicants.Any(x => x.IsCompleted &&
                                                 NormalizeString(x.PersonalInformation.FirstName) == NormalizeString(information.FirstName) &&
                                                 NormalizeString(x.PersonalInformation.MiddleName) == NormalizeString(information.MiddleName) &&
                                                 NormalizeString(x.PersonalInformation.LastName) == NormalizeString(information.LastName) &&
                                                 x.PersonalInformation.DateofBirth == information.DateofBirth);

            if (isDuplicate)
            {
                throw new InvalidOperationException($"An applicant with the same personal information already exists.");
            }


            // If the name doesn't exist, proceed with adding the new Course
            await _context.PersonalInformations.AddAsync(information);
            await _context.SaveChangesAsync();

            return information;
        }

        public async Task<ICollection<PersonalInformation>> GetAllAsync()
        {
            var informations = await _context.PersonalInformations
             .AsNoTracking()
             .ToListAsync();
            return informations;
        }

        public async Task<PersonalInformation> GetAsync(Guid id)
        {
            var information = await _context.PersonalInformations
             .AsNoTracking()
             .SingleOrDefaultAsync(a => a.Id == id);
            return information;
        }

        public async Task<PersonalInformation> UpdateAsync(PersonalInformation information)
        {
            //_context.Entry(information).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return information;
            if (information == null)
            {
                throw new ArgumentNullException(nameof(information));
            }

            // Ensure that the required fields are not null or empty
            if (string.IsNullOrWhiteSpace(information.FirstName) ||
                string.IsNullOrWhiteSpace(information.MiddleName) ||
                string.IsNullOrWhiteSpace(information.LastName)) 
            {
                throw new ArgumentException("First name, middle name, last name, and date of birth cannot be null or empty.");
            }

            // Trim leading and trailing spaces from string properties
            information.FirstName = information.FirstName.Trim();
            information.MiddleName = information.MiddleName.Trim();
            information.LastName = information.LastName.Trim();

            // Check for leading or trailing spaces
            if (!NoLeadingTrailingSpaceValidator.Validate(information.FirstName) ||
                !NoLeadingTrailingSpaceValidator.Validate(information.MiddleName) ||
                !NoLeadingTrailingSpaceValidator.Validate(information.LastName))
            {
                throw new ArgumentException("Your first name, middle name, and last name cannot have leading or trailing spaces.");
            }

            // Normalize string for comparison
            string normalizedFirstName = NormalizeString(information.FirstName);
            string normalizedMiddleName = NormalizeString(information.MiddleName);
            string normalizedLastName = NormalizeString(information.LastName);

            // Check if there is another applicant with the same name
            var applicants = await _applicantService.GetAllAsync();
            var isDuplicate = applicants.Any(x => x.IsCompleted &&
                                                 NormalizeString(x.PersonalInformation.FirstName) == normalizedFirstName &&
                                                 NormalizeString(x.PersonalInformation.MiddleName) == normalizedMiddleName &&
                                                 NormalizeString(x.PersonalInformation.LastName) == normalizedLastName &&
                                                 x.PersonalInformation.DateofBirth == information.DateofBirth &&
                                                 x.Id != information.ApplicantId);

            if (isDuplicate)
            {
                throw new InvalidOperationException($"An applicant with the same personal information already exists.");
            }

            // Update the applicant's information
            _context.Entry(information).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return information;
        }

        private string NormalizeString(string input)
        {
            //return input?.Trim().ToLowerInvariant().Replace("\\s+", " ");
            return Regex.Replace(input?.Trim().ToLowerInvariant(), @"\s+", " ");
        }

        public class NoLeadingTrailingSpaceValidator
        {
            public static bool Validate(string input)
            {
                return !string.IsNullOrWhiteSpace(input) && input == input.Trim() && input == input.TrimEnd();
            }
        }

        private bool IsValidName(string name)
        {
            // Define a regular expression pattern to match only alphabets and spaces
            string pattern = @"^[a-zA-Z\s]+$";
            //string pattern = @"^[a-zA-Z ]+$";
            return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, pattern);
        }
    }
}
