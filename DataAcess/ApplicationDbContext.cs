using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Counter> Counters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var envVariable = Environment.GetEnvironmentVariable("dbConnectionString");

            if (!string.IsNullOrEmpty(envVariable))
            {
                optionsBuilder.UseSqlServer(envVariable);
                return;
            }

            optionsBuilder.UseSqlServer("Integrated Security=true;Persist Security Info=False;User ID=;Password=*****;Initial Catalog=SystemResourceWebsite;Server=localhost");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
    }
}
