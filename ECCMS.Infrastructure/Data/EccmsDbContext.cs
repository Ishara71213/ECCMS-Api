using ECCMS.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECCMS.Infrastructure.Data
{
    public class EccmsDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public EccmsDbContext(DbContextOptions<EccmsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Province> Provinces { get; set; }

        public virtual DbSet<Institution> Institutions { get; set; }

        public virtual DbSet<Branch> Branches { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

    }
}
