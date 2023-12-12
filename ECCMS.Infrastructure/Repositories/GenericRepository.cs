using ECCMS.Core.Entities.Base;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECCMS.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly EccmsDbContext _context;

        public GenericRepository(EccmsDbContext context)
        {
            _context = context;
        }

        async Task IGenericRepository<T>.AddAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        async Task<IReadOnlyList<T>> IGenericRepository<T>.GetAllAsync()
        {
            return await _context.Set<T>().Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).ToListAsync();
        }

         async Task<T?> IGenericRepository<T>.GetByIdAsync(int id)
        {
            return await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        async Task IGenericRepository<T>.UpdateAsync(T entity)
        {
            var exists = _context.Set<T>().Any(t => t.Id == entity.Id);
            if (!exists)
                throw new Exception("Not Found");

            _context.Update(entity);
            if (entity.Id > 0)
            {
                _context.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                _context.Entry(entity).Property(x => x.CreatedOn).IsModified = false;
            }
            await _context.SaveChangesAsync();
        }
    }
}
