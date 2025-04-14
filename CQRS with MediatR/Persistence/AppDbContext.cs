using CQRS_with_MediatR.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS_with_MediatR.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            //Ensuring the database is created
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define the primary key for the Product because the EF Core will not catch it since it GUID not int
            modelBuilder.Entity<Product>().HasKey(p=>p.Id);

            //seed the table with initial records
            modelBuilder.Entity<Product>().HasData(
            new Product("iPhone 15 Pro", "Apple's latest flagship smartphone with a ProMotion display and improved cameras", 999.99m),
            new Product("Dell XPS 15", "Dell's high-performance laptop with a 4K InfinityEdge display", 1899.99m),
            new Product("Sony WH-1000XM4", "Sony's top-of-the-line wireless noise-canceling headphones", 349.99m)
        );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDB");
        }
    }
}
