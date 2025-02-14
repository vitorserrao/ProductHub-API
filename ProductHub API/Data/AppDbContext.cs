using Microsoft.EntityFrameworkCore;
using ProductHub_API.Models;

namespace ProductHub_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<ProductsModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new ProductsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

