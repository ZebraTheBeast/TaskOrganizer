﻿using TaskOrganizer.Entities;
using TaskOrganizer.DataAccess.Interfaces;
using System.Threading.Tasks;
using TaskOrganizer.Entities.Enums;
using TaskOrganizer.DataAccess.Context;
using System.Data.Entity;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class MainObjectiveRepository : BaseRepository<MainObjective>, IMainObjectiveRepository
    {
        
        TaskOrganizerContext _context;
        DbSet<MainObjective> _dbSet;

        public MainObjectiveRepository(TaskOrganizerContext context) : base(context)
        { 
            _context = context;
            _dbSet = _context.Set<MainObjective>();
        }

        public async Task UpdateStatus(long mainObjectiveId, ObjectiveStatus objectiveStatus)
        {
            var mainObjective = new MainObjective();
            mainObjective.Id = mainObjectiveId;
            mainObjective.Status = objectiveStatus;

            _context.Entry(mainObjective).Property("Status").IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
