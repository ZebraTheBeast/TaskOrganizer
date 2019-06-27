using Microsoft.EntityFrameworkCore;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DAL.Context
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
            builder.Entity<User>()
                .HasAlternateKey(user => user.Username)
                .HasName("Unique_username");

            builder.Entity<ChildObjective>()
                .HasOne(co => co.MainObjective)
                .WithMany(mo => mo.ChildObjectives)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MainObjective>()
                .HasOne(mo => mo.Category)
                .WithMany(ctg => ctg.MainObjectives)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Category>()
                .HasOne(ctg => ctg.User)
                .WithMany(u => u.Categories)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Data Source=desktop-p9v5qd9;Initial Catalog=TaskOrgDb;Integrated Security=True");
            
        }
    }
}
