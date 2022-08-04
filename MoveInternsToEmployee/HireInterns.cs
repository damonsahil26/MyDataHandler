using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MyDataHandler_DataAccess.DTO;
using MyDataHandler_Services.IServices;

namespace MoveInternsToEmployee
{
    public class HireInterns
    {
        private readonly IInternService _internService;
        private readonly IEmployeeService _employeeService;

        public HireInterns(IInternService internService, IEmployeeService employeeService)
        {
            _internService = internService;
            _employeeService = employeeService;
        }

        [FunctionName("HireInterns")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var hiredInterns = await _internService.GetAllHiredInterns();

            if (hiredInterns.Count() > 0)
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

        }
    }
}
