using UserProfileApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace UserProfileApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        // Pass database options to the base DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Interface for CRUD
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
