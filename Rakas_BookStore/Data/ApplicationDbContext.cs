using Microsoft.EntityFrameworkCore;
using Rakas_BookStore.Models;

namespace Rakas_BookStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Retrieve connectionString
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //This class passes the option to the base class
        }

        public DbSet<Category> Categories { get; set; } //Create and manage table

        //Seed dummy data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Description = "Stories centered on physical conflicts and powerful antagonists", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Romance", Description = "Love stories between characters", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", Description = "Real Past events", DisplayOrder = 3 },
                new Category { Id = 4, Name = "SciFi", Description = "Stories about advanced technology, time travel, and extraterrestrial life", DisplayOrder = 4 }
                );
        }
    }
}
