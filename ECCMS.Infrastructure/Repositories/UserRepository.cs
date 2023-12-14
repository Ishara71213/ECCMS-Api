using ECCMS.Core.Entities;
using ECCMS.Core.Enums;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECCMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EccmsDbContext _context;
        public UserRepository(EccmsDbContext context) 
        {
            _context=context;
        }

        public async Task<IReadOnlyList<User>> GetListByType(UserType type)
        {
            return await _context.Users
                .Where(x => !x.IsDelete && x.Type == type)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var items = await _context.Users.Where(x => x.Id == id).ToListAsync();
            return items.Any() ? items.First() : new User();
        }

        public async Task<User?> GetByUsernameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsMobileNoExists(UserType type, int userId, string mobileNo)
        {
            return await _context.Users.AnyAsync(x => x.Type == type && x.MobileNo == mobileNo && x.Id != userId && !x.IsDelete);
        }

        public async Task<bool> IsEmailExists(UserType type, int userId, string email)
        {
            return await _context.Users.AnyAsync(x => x.Type == type && x.Email == email && x.Id != userId && !x.IsDelete);
        }

        public async Task<bool> IsUsernameNoExists(int userId, string val)
        {
            return await _context.Users.AnyAsync(x => x.UserName == val && x.Id != userId && !x.IsDelete);
        }
    }
}
