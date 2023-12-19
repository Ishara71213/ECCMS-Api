
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;

namespace ECCMS.Application.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository) 
        {
            _provinceRepository = provinceRepository;
        }
        public async Task AddAsync(Province entity)
        {
             await _provinceRepository.AddAsync(entity);
        }

        public async Task<IReadOnlyList<Province>> GetAllAsync()
        {
            return await _provinceRepository.GetAllAsync();
        }

        public async Task<Province?> GetByIdAsync(int id)
        {
           return await _provinceRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Province entity)
        {
            await _provinceRepository.UpdateAsync(entity);
        }
    }
}
