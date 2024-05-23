using CollegeApplicationForAdmission.Services.DataContext;
using CollegeApplicationForAdmission.Services.RepositoryServices.ApplicantsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.CampusServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.CoursesServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.DepartmentsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.EducationalBackGroundsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.ParentGuardianInformationsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.PersonalInformationsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.SchedulesService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("MyConnection"),
//    sqlServerOptionsAction: sqlOptions =>
//    {
//        sqlOptions.EnableRetryOnFailure();
//    }
//    );
//}, ServiceLifetime.Transient);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
});



builder.Services.AddScoped<ICampusService, CampusService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IPersonalInformationService, PersonalInformationService>();
builder.Services.AddScoped<IEducationalBackGroundService, EducationalBackGroundService>();
builder.Services.AddScoped<IParentGuardianInformationService, ParentGuardianInformationService>();
builder.Services.AddMudServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//app.UseMiddleware<RateLimitMiddleware>(30);
app.Run();
