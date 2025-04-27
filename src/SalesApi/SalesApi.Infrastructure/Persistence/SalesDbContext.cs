using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;

namespace SalesApi.Infrastructure.Persistence;

public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>().ToTable("sales");
        modelBuilder.Entity<Product>().ToTable("products");
        
        modelBuilder.Entity<Sale>(sale =>
        {
            sale.HasKey(s => s.Id);
            sale.Property(s => s.Nummber).IsRequired().HasMaxLength(100);
            sale.Property(s => s.CustomerId).IsRequired().HasMaxLength(50);
            sale.Property(s => s.CustomerName).IsRequired().HasMaxLength(150);
            sale.Property(s => s.Date).IsRequired();
            sale.Property(s => s.TotalAmount).HasPrecision(18, 2);
            sale.Property(s => s.Branch).HasMaxLength(50);
            sale.Property(s => s.TaxValue).HasPrecision(18, 2);
            sale.Property(s => s.IsCancelled).IsRequired();

            sale.OwnsMany(s => s.Items, item =>
            {
                item.WithOwner();
                item.Property(i => i.Id).IsRequired();
                item.Property(i => i.ProductId).IsRequired();
                item.Property(i => i.ProductName).IsRequired().HasMaxLength(150);
                item.Property(i => i.Quantity).IsRequired();
                item.Property(i => i.UnitPrice).HasPrecision(18, 2).IsRequired();
                item.Property(i => i.TotalAmount).HasPrecision(18, 2).IsRequired();
            });
        });

        base.OnModelCreating(modelBuilder);
    }
}

