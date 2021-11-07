using Microsoft.EntityFrameworkCore;
using Lesson3.Models;

namespace Lesson3.Data
{
    public class MvcProductContext : DbContext
    {
        public MvcProductContext(DbContextOptions<MvcProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                new Category {Id=1, Name = "Drinks" },
                new Category {Id=2, Name = "Snacks" },
                new Category {Id=3, Name = "Milk" },
                new Category {Id=4, Name = "Meat" },
                new Category {Id=5, Name = "Cookies" },
                new Category {Id=6, Name = "Bakery" }
                });
        }
    }
}