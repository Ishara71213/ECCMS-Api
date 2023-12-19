using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECCMS.Infrastructure.Repositories
{
    public class InquiryRepository : GenericRepository<Inquiry> , IInquiryRepository
    {
        public InquiryRepository(EccmsDbContext context) : base(context)
        {
        }



    }
}
