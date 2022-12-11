using Microsoft.EntityFrameworkCore;

namespace ThAmCo_Products_WebService.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("getdate()");
        }
    }
}
