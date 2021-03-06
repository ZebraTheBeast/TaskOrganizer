﻿using TaskOrganizer.Entities;
using TaskOrganizer.DAL.Interfaces;
using System.Threading.Tasks;
using TaskOrganizer.Entities.Enums;
using TaskOrganizer.DAL.Context;
using Microsoft.EntityFrameworkCore;

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
            var mainObjective = await _dbSet.FirstOrDefaultAsync(mo => mo.Id == mainObjectiveId);
            mainObjective.Status = objectiveStatus;

            _dbSet.Update(mainObjective);
            await _context.SaveChangesAsync();
        }
    }
}
