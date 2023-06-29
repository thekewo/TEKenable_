using Microsoft.EntityFrameworkCore;

namespace TEKenable_Newsletter.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
