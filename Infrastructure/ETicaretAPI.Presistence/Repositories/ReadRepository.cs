using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entites.Common;
using ETicaretAPI.Presistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Presistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;
        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var quary = Table.AsQueryable();
            if (!isTracking)
                quary = quary.AsNoTracking();

            return quary;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool isTracking = true)
        {
            var quary = Table.Where(method);
            if (!isTracking)
                quary = quary.AsNoTracking();

            return quary;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool isTracking = true)
        {
            var quary = Table.AsQueryable();
            if (!isTracking)
                quary = Table.AsNoTracking();

            return await quary.FirstOrDefaultAsync(method);
        }

    public async Task<T> GetByIdAsync(string id, bool isTracking = true)
        {
            var quary = Table.AsQueryable();
            if (!isTracking)
                quary = Table.AsNoTracking();
            
            return await quary.FirstOrDefaultAsync(c=>c.Id == Guid.Parse(id));
        }
    }
}
