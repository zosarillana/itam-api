using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Peripherals
{  
     public class ExternalDriveContext : DbContext // Inheriting from DbContext
    {
        public ExternalDriveContext(DbContextOptions<ExternalDriveContext> options) : base(options) { }

        public DbSet<ExternalDrive> ExternalDrives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<ExternalDrive>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<ExternalDrive>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
