using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DALCore.Context
{
    public class TaskOrganizerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MainObjective> MainObjectives { get; set; }
        public DbSet<ChildObjective> ChildObjectives { get; set; }

        public TaskOrganizerContext(DbContextOptions<TaskOrganizerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
