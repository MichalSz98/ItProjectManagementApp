using Microsoft.EntityFrameworkCore;

namespace ItProjectManagementApp.Entities
{
    public class ProjectDbContext : DbContext
    {
        protected string _connectionString =
            "Server=localhost\\SQLEXPRESS;Database=ProjectDb;Trusted_Connection=True;TrustServerCertificate=True";

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Task>()
                .Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Task>()
                .HasMany(t => t.SubTasks)
                .WithOne(t => t.UserStory)
                .HasForeignKey(t => t.UserStoryId)
                .IsRequired(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
