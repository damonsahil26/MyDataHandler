using MyDataHandler_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataHandler_DataAccess.IRepository
{
    public interface IInternRepository
    {
        Task Create(InternsDTO internDtO);
        Task<IEnumerable<InternsDTO>> GetAll();
        Task<InternsDTO> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(InternsDTO internDtO);
        Task<IEnumerable<InternsDTO>> GetAllHiredInterns();
        Task ChangeHiringStatus(int id);
    }
}
