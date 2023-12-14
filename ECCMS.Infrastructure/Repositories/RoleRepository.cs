using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECCMS.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EccmsDbContext _context;
        public RoleRepository(EccmsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Role>> GetAllAsync()
        {
            return await _context.Roles
                .Include(r => r.Institution)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role> GetByNameAsync(string name)
        {
            var item = await _context.Roles.FirstOrDefaultAsync(x => x.Name == name);
            return item == null ? new Role() : item;
        }

        async Task IRoleRepository.AddAsync(Role entity)
        {
            await _context.Roles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role entity)
        {
            var exists = _context.Roles.Any(r => r.Id == entity.Id);
            if (!exists)
                throw new Exception("Not Found");
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
