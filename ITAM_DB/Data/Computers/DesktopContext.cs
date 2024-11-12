using ITAM_DB.Data.Peripherals;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Computers
{
    public class DesktopContext : DbContext
    {
        public DesktopContext(DbContextOptions<DesktopContext> options) : base(options) { }

        public DbSet<Desktop> Desktops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<Desktop>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<Desktop>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
