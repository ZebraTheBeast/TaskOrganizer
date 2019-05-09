using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskOrganizer.DAL.Context;
using TaskOrganizer.DAL.Interfaces;
using TaskOrganizer.Entities;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class ChildObjectiveRepository : BaseRepository<ChildObjective>, IChildObjectiveRepository
    {
        DbSet<ChildObjective> _dbSet;
        TaskOrganizerContext _context;

        public ChildObjectiveRepository(TaskOrganizerContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<ChildObjective>();
        }

        public async Task UpdateStatus(long childObjectiveId, ObjectiveStatus objectiveStatus)
        {
            var childObjective = new ChildObjective();
            childObjective.Id = childObjectiveId;
            childObjective.Status = objectiveStatus;

            _context.Entry(childObjective).Property("Status").IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
