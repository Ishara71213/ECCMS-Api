using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;

namespace ECCMS.Infrastructure.Repositories
{
    public class InstitutionRepository : GenericRepository<Institution> , IInstitutionRepository
    {
        
        public InstitutionRepository(EccmsDbContext context) : base(context)
        {
           
        }

      
    }
}
