using ECCMS.Core.Entities;

namespace ECCMS.Core.Interfaces.IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public Task<Employee?> GetByUserIdAsync(int userId);
        
    }
}
