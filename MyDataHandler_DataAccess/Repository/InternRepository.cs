using Microsoft.EntityFrameworkCore;
using MyDataHandler_DataAccess.DTO;
using MyDataHandler_DataAccess.IRepository;
using MyDataHandler_Domain;

namespace MyDataHandler_DataAccess.Repository
{
    public class InternRepository : IInternRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InternRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeHiringStatus(int id)
        {
            var intern = await _dbContext.Interns.FirstOrDefaultAsync(x => x.Id == id);
            if(intern != null)
            {
                intern.IsHired = true;
                _dbContext.Interns.Update(intern);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Create(InternsDTO InternsDTO)
        {
            var intern = new Interns
            {
                FirstName = InternsDTO.FirstName,
                LastName = InternsDTO.LastName,
                Address = InternsDTO.Address,
                City = InternsDTO.City,
                ContactNumber = InternsDTO.ContactNumber
            };

            _dbContext.Add(intern);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var intern = await _dbContext.Interns.FirstOrDefaultAsync(x => x.Id == id);

            if (intern != null)
            {
                _dbContext.Interns.Remove(intern);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<InternsDTO>> GetAll()
        {
            var interns = await _dbContext.Interns.ToListAsync();
            return interns.Select(x => new InternsDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                City = x.City,
                Address = x.Address,
                ContactNumber = x.ContactNumber,
                Id = x.Id,
                IsHired = x.IsHired
            });
        }

        public async Task<IEnumerable<InternsDTO>> GetAllHiredInterns()
        {
            var hiredInterns = await _dbContext.Interns.Where(x => x.IsHired).ToListAsync();

            if (!hiredInterns.Any())
            {
                return new List<InternsDTO>();
            }

            return hiredInterns.Select(x => new InternsDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                City = x.City,
                ContactNumber = x.ContactNumber,
                Id = x.Id,
                IsHired = x.IsHired
            });
        }

        public async Task<InternsDTO> GetById(int id)
        {
            var intern = await _dbContext.Interns
                .FirstOrDefaultAsync(x => x.Id == id);

            if (intern != null)
            {
                return new InternsDTO
                {
                    Id = intern.Id,
                    FirstName = intern.FirstName,
                    LastName = intern.LastName,
                    Address = intern.Address,
                    City = intern.City,
                    ContactNumber = intern.ContactNumber,
                    IsHired = intern.IsHired
                };
            }

            return new();
        }

        public async Task<bool> Update(InternsDTO InternsDTO)
        {
            var intern = await _dbContext.Interns.FirstOrDefaultAsync(x => x.Id == InternsDTO.Id);
            if (intern != null)
            {
                intern.FirstName = InternsDTO.FirstName;
                intern.LastName = InternsDTO.LastName;
                intern.Address = InternsDTO.Address;
                intern.City = InternsDTO.City;
                intern.ContactNumber = InternsDTO.ContactNumber;
                intern.IsHired = InternsDTO.IsHired;

                _dbContext.Interns.Update(intern);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }


    }
}
