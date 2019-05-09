using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskOrganizer.DAL.Context;
using TaskOrganizer.DAL.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> _dbSet;
        TaskOrganizerContext _context;

        public BaseRepository(TaskOrganizerContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity item)
        {
            var retItem = await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return retItem.Entity;
        }

        public async Task AddMultiple(List<TEntity> items)
        {
            _dbSet.AddRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(long id)
        {
            var item = await _dbSet.FindAsync(id);
            return item;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var items = await _dbSet.AsNoTracking<TEntity>().ToListAsync();
            return items;
        }

        public async Task Remove(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
