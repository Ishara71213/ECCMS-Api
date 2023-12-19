using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECCMS.Infrastructure.Repositories
{
    public class BranchRepository : GenericRepository<Branch> , IBranchRepository
    {
        public BranchRepository(EccmsDbContext context) : base(context)
        {
        }



    }
}
