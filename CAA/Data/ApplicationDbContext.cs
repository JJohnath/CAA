using CAA.Models;
using Microsoft.EntityFrameworkCore;

namespace CAA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<LeadEntity> Leads { get; set; }
    }
}
