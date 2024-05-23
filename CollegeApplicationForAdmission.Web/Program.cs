using CollegeApplicationForAdmission.Services.AuthServices;
using CollegeApplicationForAdmission.Services.DataContext;
using CollegeApplicationForAdmission.Services.RepositoryServices.ApplicantsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.CampusServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.CoursesServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.DepartmentsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.EducationalBackGroundsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.LogsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.ParentGuardianInformationsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.PersonalInformationsServices;
using CollegeApplicationForAdmission.Services.RepositoryServices.SchedulesService;
using CollegeApplicationForAdmission.Services.RepositoryServices.TransfersServices;
using CollegeApplicationForAdmission.Web.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedLocalStorage>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MyConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }
    );
}, ServiceLifetime.Transient);

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddScoped<ICampusService, CampusService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IPersonalInformationService, PersonalInformationService>();
builder.Services.AddScoped<IEducationalBackGroundService, EducationalBackGroundService>();
builder.Services.AddScoped<IParentGuardianInformationService, ParentGuardianInformationService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdminOnly", policy =>
    {
        policy.RequireRole("SuperAdmin"); // Only users with the "SuperAdmin" role
    });

    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireRole("Admin"); // Only users with the "Admin" role
    });
});

builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

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

app.Run();
