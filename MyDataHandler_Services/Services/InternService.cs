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
    public class InternService : IInternService
    {
        private readonly IInternRepository _internRepository;

        public InternService(IInternRepository employeeRepository)
        {
            _internRepository = employeeRepository;
        }

        public async Task ChangeHiringStatus(int id)
        {
           await _internRepository.ChangeHiringStatus(id);
        }

        public async Task Create(InternsDTO InternsDTO)
        {
            await _internRepository.Create(InternsDTO);
        }

        public async Task<bool> Delete(int id)
        {
            return await _internRepository.Delete(id);
        }

        public async Task<IEnumerable<InternsDTO>> GetAll()
        {
            return await _internRepository.GetAll();
        }

        public async Task<IEnumerable<InternsDTO>> GetAllHiredInterns()
        {
            return await _internRepository.GetAllHiredInterns();
        }

        public async Task<InternsDTO> GetById(int id)
        {
            return await (_internRepository.GetById(id));
        }

        public async Task<bool> Update(InternsDTO InternsDTO)
        {
            return await _internRepository.Update(InternsDTO);
        }
    }
}
