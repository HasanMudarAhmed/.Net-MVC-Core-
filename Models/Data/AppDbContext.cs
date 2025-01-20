using Microsoft.EntityFrameworkCore;
using MVCNewProject.Models;
using MVCNewProject.Data;  // Make sure this is the correct namespace for your models

namespace MVCNewProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}