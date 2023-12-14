using ECCMS.Core.Entities;

namespace ECCMS.Core.Interfaces.IServices
{
    public interface IRoleService
    {
        public Task<IReadOnlyList<Role>> GetAllAsync();

        public Task<Role?> GetByIdAsync(int id);

        public Task<Role> GetByNameAsync(string name);

        public Task AddAsync(Role entity);

        public Task UpdateAsync(Role entity);
    }
}
