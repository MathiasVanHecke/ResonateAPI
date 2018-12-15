using System;
using Microsoft.EntityFrameworkCore;

namespace Resonate.Models
{
    public class ResonateContext : DbContext
    {
        public ResonateContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<PotMatches> PotMatches { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
