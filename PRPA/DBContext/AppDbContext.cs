using Microsoft.EntityFrameworkCore;
using PRPA.Models;

namespace PRPA.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Review> Review { get; set; }
        public DbSet<Barber> Barber { get; set; }
        public DbSet<CosmeticsRequest> CosmeticsRequest { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<User> User { get; set; }
    }
}
