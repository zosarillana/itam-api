using ITAM_API.Model.Operations;
using Microsoft.EntityFrameworkCore;

namespace ITAM_API.Data
{
    public class ItotContext : DbContext // Inheriting from DbContext
    {
        public ItotContext(DbContextOptions<ItotContext> options) : base(options) { }

        // DbSet for Itot_Pc
        public DbSet<Itot_Pc> Itot_Pcs { get; set; }

        // DbSet for Itot_Peripheral
        public DbSet<Itot_Peripheral> Itot_Peripherals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration for Itot_Pc
            modelBuilder.Entity<Itot_Pc>()
                .HasKey(i => i.id);

            modelBuilder.Entity<Itot_Pc>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();

            // Configuration for Itot_Peripheral
            modelBuilder.Entity<Itot_Peripheral>()
                .HasKey(i => i.id);

            modelBuilder.Entity<Itot_Peripheral>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
