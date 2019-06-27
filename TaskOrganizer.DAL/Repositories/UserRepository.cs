using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskOrganizer.DAL.Context;
using TaskOrganizer.DAL.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        TaskOrganizerContext _context;
        DbSet<User> _dbSet;

        public UserRepository(TaskOrganizerContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public async Task<User> GetByName(string userName)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Username == userName);
            return user;
        }
    }
}
