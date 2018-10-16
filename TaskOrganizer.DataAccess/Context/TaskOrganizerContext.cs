using System.Data.Entity;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Context
{
    public class TaskOrganizerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Objective> Objectives { get; set; }

        public TaskOrganizerContext(string connectionString) : base(connectionString)
        {

        }
    }
}
