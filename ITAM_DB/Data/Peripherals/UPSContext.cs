using ITAM_API.Model.Operations;
using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Peripherals
{    
     public class UPSContext : DbContext // Inheriting from DbContext
    {
        public UPSContext(DbContextOptions<UPSContext> options) : base(options) { }

        public DbSet<UPS> UPSs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<UPS>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<UPS>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
