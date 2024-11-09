using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Peripherals
{
    public class DongleContext : DbContext
    {
        public DongleContext(DbContextOptions<DongleContext> options) : base(options) { }

        public DbSet<Dongle> Dongles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<Dongle>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<Dongle>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
