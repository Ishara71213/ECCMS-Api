using ECCMS.Core.Entities;

namespace ECCMS.Core.Interfaces.IRepositories
{
    public interface IInquiryRepository : IGenericRepository<Inquiry>
    {
        public Task<IReadOnlyList<Inquiry>> GetAllWithCrimeTypeAsync();

        public Task<int> GetLastIdAsync();
    }
}
