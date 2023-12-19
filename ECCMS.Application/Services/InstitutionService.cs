
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;

namespace ECCMS.Application.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IInstitutionRepository _institutionRepository;
        public InstitutionService(IInstitutionRepository institutionRepository) 
        {
            _institutionRepository = institutionRepository;
        }
        public async Task AddAsync(Institution entity)
        {
             await _institutionRepository.AddAsync(entity);
        }

        public async Task<IReadOnlyList<Institution>> GetAllAsync()
        {
            return await _institutionRepository.GetAllAsync();
        }

        public async Task<Institution?> GetByIdAsync(int id)
        {
           return await _institutionRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Institution entity)
        {
            await _institutionRepository.UpdateAsync(entity);
        }
    }
}
