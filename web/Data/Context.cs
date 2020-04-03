using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ExampleProjectTechnology>().HasKey(t => new { t.TechnologyId, t.ExampleProjectId });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<ExampleProject> ExampleProjects { get; set; }
        public DbSet<Outcome> Outcome { get; set; }
    }
}