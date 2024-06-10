using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UserServiceDbContext : DbContext
    {
        public UserServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        public List<User> Users { get; set; } = new();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
