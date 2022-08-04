using Microsoft.EntityFrameworkCore;
using MyDataHandler_DataAccess.DTO;
using MyDataHandler_DataAccess.IRepository;
using MyDataHandler_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataHandler_DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Address = employeeDTO.Address,
                City = employeeDTO.City,
                ContactNumber = employeeDTO.ContactNumber
            };

            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee.Result != null)
            {
                _dbContext.Employees.Remove(employee.Result);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return employees.Select(x => new EmployeeDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                City = x.City,
                Address = x.Address,
                ContactNumber = x.ContactNumber,
                Id = x.Id,
                DateOfjoining = x.DateOfjoining
            });
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                return new EmployeeDTO
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    City = employee.City,
                    ContactNumber = employee.ContactNumber
                };
            }

            return new();
        }

        public async Task<bool> Update(EmployeeDTO employeeDTO)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeDTO.Id);
            if (employee != null)
            {
                employee.FirstName = employeeDTO.FirstName;
                employee.LastName = employeeDTO.LastName;
                employee.Address = employeeDTO.Address;
                employee.City = employeeDTO.City;
                employee.ContactNumber = employeeDTO.ContactNumber;

                return true;
            }

            return false;
        }
    }
}
