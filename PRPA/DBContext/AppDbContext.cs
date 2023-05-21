using Microsoft.EntityFrameworkCore;
using PRPA.Models;

namespace PRPA.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<CosmeticsRequest> CosmeticsRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
