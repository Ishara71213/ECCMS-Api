
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;

namespace ECCMS.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository) 
        { 
            _cityRepository = cityRepository;
        }
        public async Task AddAsync(City entity)
        {
             await _cityRepository.AddAsync(entity);
        }

        public async Task<IReadOnlyList<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllAsync();
        }

        public async Task<City?> GetByIdAsync(int id)
        {
           return await _cityRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(City entity)
        {
            await _cityRepository.UpdateAsync(entity);
        }
    }
}
