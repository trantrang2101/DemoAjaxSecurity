using CoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreAPI
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("Database"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(en =>
            {
                en.HasKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Product>(en =>
            {
                en.HasKey(e => e.ProductId);

                en.HasOne(s => s.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Member>(en =>
            {
                en.HasKey(e => e.MemberId);
            });

            modelBuilder.Entity<Order>(en =>
            {
                en.HasKey(e => e.OrderId);

                en.HasOne(s => s.Member).WithMany(p => p.Orders).HasForeignKey(p => p.MemberId);
            });

            modelBuilder.Entity<OrderDetail>(en =>
            {
                en.HasKey(od => new { od.OrderId, od.ProductId });
            });

        }
    }
}
