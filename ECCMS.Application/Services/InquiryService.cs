
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;

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

        public async Task<IReadOnlyList<Inquiry>> GetAllAsync()
        {
            return await _inquiryRepository.GetAllAsync();
        }

        public async Task<Inquiry?> GetByIdAsync(int id)
        {
           return await _inquiryRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Inquiry entity)
        {
            await _inquiryRepository.UpdateAsync(entity);
        }
    }
}
