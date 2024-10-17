using ITAM_API.Model.Operations;
using Microsoft.EntityFrameworkCore;

namespace ITAM_API.Data.Itot
{
    public class Itot_PeripheralContext : DbContext // Inheriting from DbContext
    {
        public Itot_PeripheralContext(DbContextOptions<Itot_PeripheralContext> options) : base(options) { }

        public DbSet<Itot_Peripheral> Itot_Peripherals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<Itot_Pc>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<Itot_Pc>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
