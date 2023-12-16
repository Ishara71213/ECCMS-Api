
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;

namespace ECCMS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public async Task AddAsync(Employee entity)
        {
            await _employeeRepository.AddAsync(entity);
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<Employee?> GetByUserIdAsync(int userId)
        {
           return await _employeeRepository.GetByUserIdAsync(userId);
        }

        public async Task UpdateAsync(Employee entity)
        {
             await _employeeRepository.UpdateAsync(entity);
        }
    }
}
