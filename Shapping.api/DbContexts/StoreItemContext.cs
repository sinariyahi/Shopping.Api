using Microsoft.EntityFrameworkCore;
using Shapping.api.Configuration;
using Shapping.api.Entities;


namespace Shapping.api.DbContexts
{
    public class StoreItemContext : DbContext
    {
        public StoreItemContext(DbContextOptions<StoreItemContext> options) : base(options)
        {
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

