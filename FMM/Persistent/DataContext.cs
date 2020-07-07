using Microsoft.EntityFrameworkCore;

namespace FMM.Persistent
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Dream> Dreams { get; set; }
        public DbSet<Dreamer> Dreamers { get; set; }
    }
}