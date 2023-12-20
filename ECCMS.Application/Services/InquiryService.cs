
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;
using System.Transactions;

namespace ECCMS.Application.Services
{
    public class InquiryService : IInquiryService
    {
        private readonly IInquiryRepository _inquiryRepository;
        public InquiryService(IInquiryRepository inquiryRepository) 
        {
            _inquiryRepository = inquiryRepository;
        }
        public async Task AddAsync(Inquiry entity)
        {
             await _inquiryRepository.AddAsync(entity);
        }

        public async Task<string> GenerateTicketId()
        {
            int lastEntryId = await _inquiryRepository.GetLastIdAsync();
            DateTime nowDate = DateTime.UtcNow;
            string year= nowDate.Year.ToString();
            string newTicketId = $"TKT{year}-{lastEntryId + 1:D6}";
            return newTicketId;
        }

        public async Task<IReadOnlyList<Inquiry>> GetAllAsync()
        {
            return await _inquiryRepository.GetAllAsync();
        }

        public async Task<IReadOnlyList<Inquiry>> GetAllWithCrimeTypeAsync()
        {
            return await _inquiryRepository.GetAllWithCrimeTypeAsync();
        }

        public async Task<Inquiry?> GetByIdAsync(int id)
        {
           return await _inquiryRepository.GetByIdAsync(id);
        }

        public async Task<int> GetLastIdAsync()
        {
            return await _inquiryRepository.GetLastIdAsync();
        }



        public async Task UpdateAsync(Inquiry entity)
        {
            await _inquiryRepository.UpdateAsync(entity);
        }
    }
}
