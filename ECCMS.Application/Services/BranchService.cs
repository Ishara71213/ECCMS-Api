
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;

namespace ECCMS.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        public BranchService(IBranchRepository cityRepository) 
        {
            _branchRepository = cityRepository;
        }
        public async Task AddAsync(Branch entity)
        {
             await _branchRepository.AddAsync(entity);
        }

        public async Task<IReadOnlyList<Branch>> GetAllAsync()
        {
            return await _branchRepository.GetAllAsync();
        }

        public async Task<Branch?> GetByIdAsync(int id)
        {
           return await _branchRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Branch entity)
        {
            await _branchRepository.UpdateAsync(entity);
        }
    }
}
