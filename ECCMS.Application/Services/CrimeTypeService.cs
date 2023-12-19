
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;

namespace ECCMS.Application.Services
{
    public class CrimeTypeService : ICrimeTypeService
    {
        private readonly ICrimeTypeRepository _crimeTypeRepository;
        public CrimeTypeService(ICrimeTypeRepository crimeTypeRepository) 
        {
            _crimeTypeRepository = crimeTypeRepository;
        }
        public async Task AddAsync(CrimeType entity)
        {
             await _crimeTypeRepository.AddAsync(entity);
        }

        public async Task<IReadOnlyList<CrimeType>> GetAllAsync()
        {
            return await _crimeTypeRepository.GetAllAsync();
        }

        public async Task<CrimeType?> GetByIdAsync(int id)
        {
           return await _crimeTypeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(CrimeType entity)
        {
            await _crimeTypeRepository.UpdateAsync(entity);
        }
    }
}
