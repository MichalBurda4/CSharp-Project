using Microsoft.EntityFrameworkCore;
using PZ2_PROJECT.Models;

namespace PZ2_PROJECT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Opinion> Opinion { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(m => m.MovieID);
            modelBuilder.Entity<User>().HasKey(u => u.UserID);
            modelBuilder.Entity<Opinion>()
                .HasKey(o => new { o.MovieID, o.UserID });

            modelBuilder.Entity<Opinion>()
                .HasOne(o => o.Movie)
                .WithMany(m => m.Opinions)
                .HasForeignKey(o => o.MovieID);

            modelBuilder.Entity<Opinion>()
                .HasOne(o => o.User)
                .WithMany(u => u.Opinions)
                .HasForeignKey(o => o.UserID);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}