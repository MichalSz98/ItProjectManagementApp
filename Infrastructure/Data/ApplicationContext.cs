using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        protected string _connectionString =
            "Server=localhost\\SQLEXPRESS;Database=ProjectDb;Trusted_Connection=True;TrustServerCertificate=True";

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Task>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, b => b.MigrationsAssembly("ItProjectManagementApp"));
        }
    }
}
