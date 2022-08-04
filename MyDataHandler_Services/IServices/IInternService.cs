using MyDataHandler_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataHandler_Services.IServices
{
    public interface IInternService
    {
        Task Create(InternsDTO internDTO);
        Task<IEnumerable<InternsDTO>> GetAll();
        Task<InternsDTO> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(InternsDTO internsDTO);
        Task<IEnumerable<InternsDTO>> GetAllHiredInterns();
        Task ChangeHiringStatus(int id);
    }
}
