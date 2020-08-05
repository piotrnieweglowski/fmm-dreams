using Microsoft.EntityFrameworkCore;

namespace FMM.Persistent
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dreamer>()
                .HasOne(d => d.Dream)
                .WithOne(d => d.Dreamer)
                .HasForeignKey<Dream>(d => d.DreamerId);

            modelBuilder.Entity<DreamCategory>()
                .HasOne(dc => dc.Dream)
                .WithMany(d => d.Categories)
                .HasForeignKey(dc => dc.DreamId);
            
            modelBuilder.Entity<DreamCategory>()
                .HasOne(dc => dc.Category)
                .WithMany(c => c.Dreams)
                .HasForeignKey(dc => dc.CategoryId);
            
            modelBuilder.Entity<DreamVolunteer>()
                .HasOne(dv => dv.Dream)
                .WithMany(d => d.Volunteers)
                .HasForeignKey(dv => dv.DreamId);

            modelBuilder.Entity<DreamVolunteer>()
                .HasOne(dv => dv.Volunteer)
                .WithMany(v => v.Dreams)
                .HasForeignKey(dv => dv.VolunteerId);
        }

        public DbSet<Dream> Dreams { get; set; }
        public DbSet<Dreamer> Dreamers { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
    }
}