﻿// <auto-generated />
using System;
using CollegeApplicationForAdmission.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollegeApplicationForAdmission.Services.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519012524_DatabaseTables")]
    partial class DatabaseTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Applicant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicantStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControlNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamTimeTaken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("GWA")
                        .HasColumnType("float");

                    b.Property<int?>("IntelligenceRawScore")
                        .HasColumnType("int");

                    b.Property<int?>("InterviewAnalytical")
                        .HasColumnType("int");

                    b.Property<int?>("InterviewCommunication")
                        .HasColumnType("int");

                    b.Property<int?>("InterviewReading")
                        .HasColumnType("int");

                    b.Property<bool>("IsExamined")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInterviewed")
                        .HasColumnType("bit");

                    b.Property<int?>("MathRawScore")
                        .HasColumnType("int");

                    b.Property<int?>("ReadingRawScore")
                        .HasColumnType("int");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ScienceRawScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Campus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasDepartment")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Campuses");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.EducationalBackground", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Honors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LRN")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("SchoolAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolLastAttended")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolSector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Track")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearGraduated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId")
                        .IsUnique();

                    b.ToTable("EducationalBackgrounds");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Process")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.ParentGuardianInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FatherCitizenship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherMiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianCitizenship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianMiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherCitizenship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherMiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId")
                        .IsUnique();

                    b.ToTable("ParentGuardianInformations");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.PersonalInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Barangay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Citizenship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId")
                        .IsUnique();

                    b.ToTable("PersonalInformations");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Meridiem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ScheduleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Slot")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Transfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FromCampus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromProgram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToCampus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToProgram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransferredDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Applicant", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.Schedule", "Schedule")
                        .WithMany("Applicants")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Course", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.Campus", "Campus")
                        .WithMany("Courses")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Campus");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Department", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.Campus", "Campus")
                        .WithMany("Departments")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campus");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.EducationalBackground", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.Applicant", "Applicant")
                        .WithOne("EducationalBackground")
                        .HasForeignKey("CollegeApplicationForAdmission.Models.Entities.EducationalBackground", "ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Log", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.User", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.ParentGuardianInformation", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.Applicant", "Applicant")
                        .WithOne("ParentGuardianInformation")
                        .HasForeignKey("CollegeApplicationForAdmission.Models.Entities.ParentGuardianInformation", "ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.PersonalInformation", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.Applicant", "Applicant")
                        .WithOne("PersonalInformation")
                        .HasForeignKey("CollegeApplicationForAdmission.Models.Entities.PersonalInformation", "ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Schedule", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.Campus", "Campus")
                        .WithMany("Schedules")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campus");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Transfer", b =>
                {
                    b.HasOne("CollegeApplicationForAdmission.Models.Entities.User", "User")
                        .WithMany("Transfers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Applicant", b =>
                {
                    b.Navigation("EducationalBackground")
                        .IsRequired();

                    b.Navigation("ParentGuardianInformation")
                        .IsRequired();

                    b.Navigation("PersonalInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Campus", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Departments");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.Schedule", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("CollegeApplicationForAdmission.Models.Entities.User", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("Transfers");
                });
#pragma warning restore 612, 618
        }
    }
}
