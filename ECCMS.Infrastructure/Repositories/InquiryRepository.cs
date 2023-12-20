using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;
using ECCMS.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ECCMS.Infrastructure.Repositories
{
    public class InquiryRepository : GenericRepository<Inquiry> , IInquiryRepository
    {
        private readonly EccmsDbContext _context;

        public InquiryRepository(EccmsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Inquiry>> GetAllWithCrimeTypeAsync()
        {
            return await _context.Inquiries.Where(x => !x.IsDeleted)
                .Include(r => r.CrimeType)
                .OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<int> GetLastIdAsync()
        {
            var lastTicket = await _context.Inquiries.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
            return lastTicket == null ? 0 : lastTicket.Id;
        }
    }
}
