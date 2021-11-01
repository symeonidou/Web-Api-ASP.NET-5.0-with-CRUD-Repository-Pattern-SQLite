using Microsoft.EntityFrameworkCore;
using StoreDemo.Entities;

namespace StoreDemo.AppDbContext
{
    public class DataDbContext : DbContext
    {
        //SQLite Db connection
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite(@"Data Source = C:\Users\Emma\source\repos\WebApi\StoreDemo\DemoDb.db");

        public DataDbContext(DbContextOptions<DataDbContext> options): base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // Set Primary Key
            modelBuilder.Entity<Product>().HasKey(s => s.Id);
            modelBuilder.Entity<Category>().HasKey(s => s.CategoryId);

            // Entity–relationship model
            modelBuilder.Entity<Product>()
                .HasOne(s => s.Category)
                .WithMany(s => s.Products)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
