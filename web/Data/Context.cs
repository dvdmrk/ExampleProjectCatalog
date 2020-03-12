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
        DbSet<Student> Students { get; set; }
        DbSet<Technology> Technologies { get; set; }
        DbSet<Milestone> Milestones { get; set; }
        DbSet<ExampleProject> ExampleProjects { get; set; }
    }
}