using MyDataHandler_DataAccess.DTO;
using MyDataHandler_DataAccess.IRepository;
using MyDataHandler_Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataHandler_Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Create(EmployeeDTO employeeDTO)
        {
            await _employeeRepository.Create(employeeDTO);
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.Delete(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            return await (_employeeRepository.GetById(id));
        }

        public async Task<bool> Update(EmployeeDTO employeeDTO)
        {
            return await _employeeRepository.Update(employeeDTO);
        }
    }
}
