using CAA.Models;
using Microsoft.EntityFrameworkCore;

namespace CAA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<eventsEntity> Events { get; set; }
    }
}
