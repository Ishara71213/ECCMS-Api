using ECCMS.Core.Entities;

namespace ECCMS.Core.Interfaces.IServices
{
    public interface IInquiryService : IGenericService<Inquiry>
    {
        public Task<IReadOnlyList<Inquiry>> GetAllWithCrimeTypeAsync();

        public Task<int> GetLastIdAsync();

        public Task<string> GenerateTicketId();
    }
}
