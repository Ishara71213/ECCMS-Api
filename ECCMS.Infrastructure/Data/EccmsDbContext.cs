using ECCMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECCMS.Infrastructure.Data
{
    public class EccmsDbContext : DbContext
    {
        public EccmsDbContext(DbContextOptions<EccmsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public  DbSet<Role> Roles { get; set; }
        public virtual DbSet<Province> provinces { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
    }
}
