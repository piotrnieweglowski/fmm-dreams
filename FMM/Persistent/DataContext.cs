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
        public DbSet<Step> Steps { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}