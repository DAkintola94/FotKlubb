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

    }
}
