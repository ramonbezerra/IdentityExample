using Domain.Models;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);

            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1, 
                    Username = "batman", 
                    Email = "batman@email.com",
                    Password = "batman", 
                    Role = "manager" 
                },
                new User 
                { 
                    Id = 2, 
                    Username = "robin", 
                    Email = "robin@email.com",
                    Password = "robin", 
                    Role = "employee" 
                }
            );

        }

        public DbSet<User> Users { get; set; }
    }
}
