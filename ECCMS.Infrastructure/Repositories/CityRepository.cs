using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;

namespace ECCMS.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City> , ICityRepository
    {
        
        public CityRepository(EccmsDbContext context) : base(context)
        {
           
        }

      
    }
}
