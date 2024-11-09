using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Peripherals
{    
   public class LanAdapterContext : DbContext // Inheriting from DbContext
    {
        public LanAdapterContext(DbContextOptions<LanAdapterContext> options) : base(options) { }

        public DbSet<LanAdapter> LanAdapters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<LanAdapter>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<LanAdapter>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
