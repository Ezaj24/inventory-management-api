using Microsoft.EntityFrameworkCore;
using InventoryManagement.Api.Models;



namespace InventoryManagement.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
    {

    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
             .HasMany(c => c.Products)
             .WithOne(p => p.Category)
             .HasForeignKey(p => p.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Product>()
            .HasOne(p => p.InventoryItem)
            .WithOne(i => i.Product)
            .HasForeignKey<InventoryItem>(i => i.ProductId);


            

            
    }
}