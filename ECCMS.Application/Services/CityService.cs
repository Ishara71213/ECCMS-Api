
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
        public Task AddAsync(City entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllAsync();
        }

        public Task<City?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(City entity)
        {
            throw new NotImplementedException();
        }
    }
}
