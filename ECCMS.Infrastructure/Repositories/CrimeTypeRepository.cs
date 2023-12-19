using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECCMS.Infrastructure.Repositories
{
    public class CrimeTypeRepository : GenericRepository<CrimeType> , ICrimeTypeRepository
    {
        public CrimeTypeRepository(EccmsDbContext context) : base(context)
        {
        }



    }
}
