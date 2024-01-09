using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tutorial.Models;

namespace Tutorial.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Build> Builds { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

    }
}
