using Microsoft.EntityFrameworkCore;
using UserProfileApi.Models;

namespace UserProfileApi.Data
{
    public class AppDbContext : DbContext
    {
        // Pass database options to the base DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Interface for CRUD
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
