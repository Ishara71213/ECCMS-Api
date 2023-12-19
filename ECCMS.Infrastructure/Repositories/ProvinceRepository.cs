using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;

namespace ECCMS.Infrastructure.Repositories
{
    public class ProvinceRepository : GenericRepository<Province> , IProvinceRepository
    {
        
        public ProvinceRepository(EccmsDbContext context) : base(context)
        {
           
        }

      
    }
}
