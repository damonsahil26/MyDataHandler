using MyDataHandler_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataHandler_DataAccess.IRepository
{
    public interface IEmployeeRepository
    {
        Task Create(EmployeeDTO employeeDTO);
        Task<IEnumerable<EmployeeDTO>> GetAll();
        Task<EmployeeDTO> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(EmployeeDTO employeeDTO);
    }
}
