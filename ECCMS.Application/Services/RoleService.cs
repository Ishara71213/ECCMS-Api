using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECCMS.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IReadOnlyList<Role>> GetAllAsync()
        {
            return (await _roleRepository.GetAllAsync()).OrderByDescending(r => r.CreatedOn).ToList();
        }

        public async Task<Role?> GetByIdAsync(int roleId)
        {
            return await _roleRepository.GetByIdAsync(roleId);
        }

        public async Task<Role> GetByNameAsync(string name)
        {
            return await _roleRepository.GetByNameAsync(name);
        }

        public async Task AddAsync(Role role)
        {
            await _roleRepository.AddAsync(role);
        }

        public async Task UpdateAsync(Role entity)
        {
            await _roleRepository.UpdateAsync(entity);
        }
    }
}
