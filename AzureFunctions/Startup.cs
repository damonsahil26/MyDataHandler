using AzureFunctions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyDataHandler_DataAccess;
using MyDataHandler_DataAccess.IRepository;
using MyDataHandler_DataAccess.Repository;
using MyDataHandler_Services.IServices;
using MyDataHandler_Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: WebJobsStartup(typeof(Startup))]
namespace AzureFunctions
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=tcp:tcs-poc-employee.database.windows.net,1433;Initial Catalog=tcs_employee_db;Persist Security Info=False;User ID=admin_tcs;Password=Tata@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IInternRepository, InternRepository>();
            builder.Services.AddScoped<IInternService, InternService>();
        }
    }

}
