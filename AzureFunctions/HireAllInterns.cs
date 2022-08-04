using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MyDataHandler_DataAccess.DTO;
using MyDataHandler_Services.IServices;

namespace AzureFunctions
{
    public class HireAllInterns
    {
        private readonly IEmployeeService _employeeService;
        private readonly IInternService _internService;

        public HireAllInterns(IEmployeeService employeeService, IInternService internService)
        {
            _employeeService = employeeService;
            _internService = internService;
        }

        [FunctionName("HireAllInterns")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var hiredInterns = await _internService.GetAllHiredInterns();

            if (hiredInterns.Any())
            {
                foreach (var intern in hiredInterns)
                {
                    await _employeeService.Create(new EmployeeDTO
                    {
                        FirstName = intern.FirstName,
                        LastName = intern.LastName,
                        Address = intern.Address,
                        City = intern.City,
                        ContactNumber = intern.ContactNumber,
                        DateOfjoining = DateTime.Now
                    });

                    await _internService.Delete(intern.Id);
                }
            }

            log.LogInformation($"Total Interns now moved to employees are : {hiredInterns.Count()}");
        }
    }
}
