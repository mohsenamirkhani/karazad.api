using Microsoft.EntityFrameworkCore;
using razorPage.Data.Models;
using razorPage.Models;

namespace razorPage.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}