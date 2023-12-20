using ECCMS.Core.Entities;

namespace ECCMS.Core.Interfaces.IServices
{
    public interface IEmployeeService : IGenericService<Employee>
    {
        public Task<Employee?> GetByUserIdAsync(int userId);

        public Task<IReadOnlyList<Employee>> GetAllWithUserDataAsync();
    }
}
