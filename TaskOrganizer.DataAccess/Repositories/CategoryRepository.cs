using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TaskOrganizer.DataAccess.Context;
using TaskOrganizer.DataAccess.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        DbSet<Category> _dbSet;
        TaskOrganizerContext _context;

        public CategoryRepository(TaskOrganizerContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        public async Task<List<Category>> GetCategoriesByUserId(long userId)
        {
            var categories = new List<Category>();

            categories = await _context.Categories.Where(obj => obj.UserId == userId).ToListAsync();

            return categories;
        }
    }
}
