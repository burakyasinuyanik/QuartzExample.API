using Microsoft.EntityFrameworkCore;
using QuartzExample.API.Models;

namespace QuartzExample.API.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }

    }
}
