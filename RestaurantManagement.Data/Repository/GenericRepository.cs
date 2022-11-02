using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data.Entities.Base;
using RestaurantManagement.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Data.DataContext;

namespace RestaurantManagement.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly RestaurantContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(RestaurantContext context)
        {
            this._context = context;
            _table = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public IQueryable<T> GetAll(string include)
        {
            return _table.AsQueryable().Include(include);
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public async Task InsertAsync(T obj)
        {
            await _table.AddAsync(obj);

        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _table.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _table.FindAsync(id);
            _table.Remove(entity);
        }

        public async Task SaveAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.LastUpdateAt = now;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.LastUpdateAt = now;
                            break;
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
