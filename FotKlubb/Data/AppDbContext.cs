using FotKlubb.Models;
using Microsoft.EntityFrameworkCore;

namespace FotKlubb.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CreateProfileModel> ProfileCreation { get; set; }
        public DbSet<PositionModel> Position_model { get; set; }
        public DbSet<LoginProfileModel> LoginProfile { get; set; }
        public DbSet<UsersActivity> UserActivity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreateProfileModel>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }


    }
}
