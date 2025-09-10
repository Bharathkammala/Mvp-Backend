using Microsoft.EntityFrameworkCore;
using MVPBackend.Models;

namespace MVPBackend.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
            public DbSet<Team> Teams { get; set; }
            public DbSet<TeamMember> TeamMembers { get; set; }
            public DbSet<Project> Projects { get; set; }
            public DbSet<ProjectTeam> ProjectTeams { get; set; }
            public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasKey(t => t.TaskId);

            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.UserId });

            modelBuilder.Entity<ProjectTeam>()
                .HasKey(pt => new { pt.ProjectId, pt.TeamId });
        }
    }
}
