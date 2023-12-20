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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly EccmsDbContext _context;
        public EmployeeRepository(EccmsDbContext context) : base(context) 
        {
            _context=context;
        }

        public async Task<IReadOnlyList<Employee>> GetAllWithUserDataAsync()
        {
            return await _context.Employees.Where(x => !x.IsDeleted)
                .Include(r => r.User)
                .OrderByDescending(x => x.Id).ToListAsync();
        }
    
        public async Task<Employee?> GetByUserIdAsync(int userId)
        {
            return await _context.Employees
                .Include(r => r.User)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
